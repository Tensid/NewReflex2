using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;
using ArchiveService;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Data.Models;
using VisaRService;
using VisaRService.Contracts;
using WcfCoreMtomEncoder;

namespace ReflexIipaxService
{
    public class IipaxServiceFactory
    {
        private readonly IipaxSettings _settings;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IipaxServiceFactory> _logger;

        public IipaxServiceFactory(ApplicationDbContext context, ILogger<IipaxServiceFactory> logger)
        {
            _settings = context.IipaxSettings.FirstOrDefault();
            _context = context;
            _logger = logger;
        }

        public IipaxService Create(Guid id)
        {
            var iipaxConfig = _context.IipaxConfigs.FirstOrDefault(x => x.Id == id);
            return new IipaxService(_settings, iipaxConfig, _logger);
        }
    }

    public class IipaxService : IVisaRService
    {
        private readonly string _url;
        private readonly IipaxConfig _config;
        private readonly ILogger _logger;
        private const string BaseId = "iipax://objectbase.document/docpartition#";
        private readonly (Visibility, Visibility, Visibility) caseVisibility;
        private readonly (Visibility, Visibility, Visibility) docVisibility;
        private readonly (Visibility, Visibility, Visibility) fileVisibility;

        public IipaxService(IipaxSettings settings, IipaxConfig config, ILogger logger)
        {
            _url = settings?.ServiceUrl;
            _config = config;
            _logger = logger;
            caseVisibility = (_config.CaseSecrecyVisibility, _config.CasePulPersonalSecrecyVisibility, _config.CaseOtherSecrecyVisibility);
            docVisibility = (_config.DocSecrecyVisibility, _config.DocPulPersonalSecrecyVisibility, _config.DocOtherSecrecyVisibility);
            fileVisibility = (_config.FileSecrecyVisibility, _config.FilePulPersonalSecrecyVisibility, _config.FileOtherSecrecyVisibility);
        }

        private ArchivePortTypeClient GetClient()
        {
            var binding = new BasicHttpBinding
            {
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                Security =
                {
                    Mode =
                        _url.StartsWith("https:")
                            ? BasicHttpSecurityMode.Transport
                            : BasicHttpSecurityMode.TransportCredentialOnly,
                    Transport = {ClientCredentialType = HttpClientCredentialType.Ntlm}
                }
            };

            var client = new ArchivePortTypeClient(binding, new EndpointAddress(_url));

            return client;
        }

        private ArchivePortTypeClient GetMtomClient()
        {
            var encoding = new MtomMessageEncoderBindingElement(new TextMessageEncodingBindingElement { ReaderQuotas = XmlDictionaryReaderQuotas.Max });

            var transport = _url.StartsWith("https:") ? new HttpsTransportBindingElement
            {
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue
            }
            : new HttpTransportBindingElement
            {
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue
            };

            var customBinding = new CustomBinding(encoding, transport);
            var client = new ArchivePortTypeClient(customBinding, new EndpointAddress(_url));
            return client;
        }

        public async Task<Case[]> GetCasesByEstate(string estateId)
        {
            var client = GetClient();
            var query = new Query
            {
                SearchCondition = new[]
                {
                    new SearchCondition {Attribute = "property_name", Operator = Operator.EQUAL, Value = new[] {estateId}}
                }
            };
            var options = new SearchOptions
            {
                RequestedAttributes = new[]
                {
                    "case_sentence", "decision_date", "display_name", "secrecy", "pul_personal_secrecy", "other_secrecy"
                },
                SortOrder = new[] { new SortOrderDirective { Attribute = "display_name", Order = Order.ASC } }
            };

            var response = await client.SearchAipsAsync(new SearchAips { Query = new[] { query }, callerId = "reflex", Options = options });
            return response?.SearchAipsResponse?.ArchiveObject?.Where(o => !ContainsSecrecy(o, caseVisibility))
                .Where(x => _config.ObjectTypes?.Any() != true || _config.ObjectTypes.Contains(x.ObjectType))
                .Select(o => new Case
                {
                    CaseSource = "iipax",
                    CaseId = o.Id.Replace(BaseId, ""),
                    Dnr = o.DisplayName,
                    Date = TryConvertDate(o, "decision_date"),
                    Title = o.Attribute.FindValue("case_sentence"),
                    UnavailableDueToSecrecy = UnavailableDueToSecrecy(o, caseVisibility)
                }).ToArray() ?? Array.Empty<Case>();
        }

        public Task<Occurence[]> GetOccurencesByCase(string caseId)
        {
            return null;
        }

        public async Task<PhysicalDocument> GetDocument(string documentId)
        {
            var client = GetMtomClient();
            var file = (await client.GetFileContentAsync(new GetFileContent { callerId = "reflex", Id = BaseId + documentId })).GetFileContentResponse.File;

            if (ContainsSecrecy(file, fileVisibility) || UnavailableDueToSecrecy(file, fileVisibility))
                throw new SecurityException();

            return new PhysicalDocument
            {
                Data = file.Content.Data,
                Filename = file.DisplayName
            };
        }

        public Task<Preview> GetPreviewByCase(string caseId)
        {
            return null;
        }

        public Task<CasePerson[]> GetPersonsByCase(string caseId)
        {
            return null;
        }

        public async Task<ArchivedDocument[]> GetArchivedDocumentsByCase(string caseId)
        {
            var client = GetClient();
            var archiveObject = (await client.GetAipAsync(new GetAip
            {
                Id = BaseId + caseId,
                callerId = "reflex",
                RequestedAttributes = new[] { "case_sentence", "description", "secrecy", "pul_personal_secrecy", "other_secrecy" }
            })).GetAipResponse.ArchiveObject;

            if (ContainsSecrecy(archiveObject, caseVisibility))
                return Array.Empty<ArchivedDocument>();

            var archivedDocuments = new List<ArchivedDocument>();

            var archivedDocument = new ArchivedDocument
            {
                Title = archiveObject.DisplayName,
                Secrecy = archiveObject.Attribute.FindValue("secrecy"),
                OtherSecrecy = archiveObject.Attribute.FindValue("pul_personal_secrecy"),
                PulPersonalSecrecy = archiveObject.Attribute.FindValue("other_secrecy"),
                UnavailableDueToSecrecy = UnavailableDueToSecrecy(archiveObject, caseVisibility),
                Docs = archiveObject?.Items?.Cast<ArchiveService.Document>().Where(x => !ContainsSecrecy(x, docVisibility)).Select(document => new Doc
                {
                    Title = document.DisplayName,
                    Secrecy = document.Attribute.FindValue("secrecy"),
                    OtherSecrecy = document.Attribute.FindValue("pul_personal_secrecy"),
                    PulPersonalSecrecy = document.Attribute.FindValue("other_secrecy"),
                    UnavailableDueToSecrecy = UnavailableDueToSecrecy(document, docVisibility),
                    Files = document?.File?.Where(x => !ContainsSecrecy(x, fileVisibility)).Select(file => new File
                    {
                        Title = file?.DisplayName ?? "Fil saknas",
                        PhysicalDocumentId = file?.Id?.Replace(BaseId, "") ?? "-1",
                        Secrecy = file?.Attribute.FindValue("secrecy"),
                        OtherSecrecy = file?.Attribute.FindValue("pul_personal_secrecy"),
                        PulPersonalSecrecy = file?.Attribute.FindValue("other_secrecy"),
                        UnavailableDueToSecrecy = UnavailableDueToSecrecy(file, fileVisibility)
                    })
                })
            };
            archivedDocuments.Add(archivedDocument);
            return archivedDocuments.ToArray();
        }

        public async Task<Case> GetCase(string caseId)
        {
            try
            {
                var client = GetClient();
                var archiveObject = (await client.GetAipAsync(new GetAip
                {
                    Id = BaseId + caseId,
                    callerId = "reflex",
                    RequestedAttributes = new[]
                    {
                        "case_sentence", "decision_date", "description",
                        "secrecy", "pul_personal_secrecy", "other_secrecy"
                    }
                })).GetAipResponse.ArchiveObject;

                if (archiveObject == null || ContainsSecrecy(archiveObject, docVisibility))
                    return null;

                return new Case
                {
                    Beskrivning = archiveObject.Attribute.FindValue("description"),
                    CaseId = archiveObject.Id.Replace(BaseId, ""),
                    Dnr = archiveObject.DisplayName,
                    Title = archiveObject.Attribute.FindValue("case_sentence"),
                    CaseSource = "iipax",
                    Fastighetsbeteckning = archiveObject.Attribute.FindValue("property_name"),
                    CaseSourceId = _config.Id,
                    Date = TryConvertDate(archiveObject, "decision_date"),
                    UnavailableDueToSecrecy = UnavailableDueToSecrecy(archiveObject, caseVisibility)
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Case> SearchCase(string caseNumber)
        {
            try
            {
                var cases = new List<Task<Case[]>>();
                var caseResult = SearchAips("display_name", Operator.MATCHES, caseNumber + "*", null);

                return (await caseResult).ToArray()?.FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Task<Case[]>>> SearchCases(string caseNumber)
        {
            var cases = new List<Task<Case[]>>();
            var alternativBeteckningCases = SearchAips("alternative_property_names", Operator.EQUAL, caseNumber, "Alt bet");
            var objektlistaCases = SearchAips("object_reference_extra", Operator.EQUAL, caseNumber, "Objektlista");
            cases.Add(alternativBeteckningCases);
            cases.Add(objektlistaCases);
            var result = Task.FromResult(cases);

            return await result.ConfigureAwait(false);
        }

        private async Task<Case[]> SearchAips(string attribute, Operator @operator, string value, string type)
        {
            try
            {
                var client = GetClient();
                var query = new Query { SearchCondition = new[] { new SearchCondition { Attribute = attribute, Operator = @operator, Value = new[] { value } } } };
                var options = new SearchOptions
                {
                    RequestedAttributes = new[]
                    {
                        "case_sentence", "decision_date", "display_name", "property_name",
                        "secrecy", "pul_personal_secrecy", "other_secrecy"
                    },
                    SortOrder = new[] { new SortOrderDirective { Attribute = "display_name", Order = Order.ASC } }
                };

                var response = (await client.SearchAipsAsync(new SearchAips { Query = new[] { query }, callerId = "reflex", Options = options }))?.SearchAipsResponse;
                return response?.ArchiveObject?.Where(o => !ContainsSecrecy(o, caseVisibility))
                    .Where(x => _config.ObjectTypes?.Any() != true || _config.ObjectTypes.Contains(x.ObjectType))
                    .Select(o => new Case
                    {
                        CaseSource = "iipax",
                        CaseId = o.Id.Replace(BaseId, ""),
                        Dnr = o.DisplayName,
                        Title = o.DisplayName,
                        Date = TryConvertDate(o, "decision_date"),
                        CaseSourceId = _config.Id,
                        Fastighetsbeteckning = o.Attribute.FindValue("property_name"),
                        UnavailableDueToSecrecy = UnavailableDueToSecrecy(o, caseVisibility),
                        Type = type
                    }).ToArray();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
                return null;
            }
        }

        private static bool ContainsSecrecy(IipaxObject archiveObject, (Visibility secrecyVisibility, Visibility pulPersonalSecrecyVisibility, Visibility otherSecrecyVisibility) visibility)
        {
            int.TryParse(archiveObject?.Attribute?.FindValue("secrecy"), out var secrecy);
            int.TryParse(archiveObject?.Attribute?.FindValue("pul_personal_secrecy"), out var pulPersonalSecrecy);
            int.TryParse(archiveObject?.Attribute?.FindValue("other_secrecy"), out var otherSecrecy);

            if (secrecy >= 10 && (visibility.secrecyVisibility) == Visibility.Hide)
                return true;
            if (pulPersonalSecrecy >= 10 && (visibility.pulPersonalSecrecyVisibility) == Visibility.Hide)
                return true;
            if (otherSecrecy >= 10 && (visibility.otherSecrecyVisibility) == Visibility.Hide)
                return true;
            return false;
        }

        private static bool UnavailableDueToSecrecy(IipaxObject archiveObject, (Visibility secrecyVisibility, Visibility pulPersonalSecrecyVisibility, Visibility otherSecrecyVisibility) visibility)
        {
            int.TryParse(archiveObject?.Attribute?.FindValue("secrecy"), out var secrecy);
            int.TryParse(archiveObject?.Attribute?.FindValue("pul_personal_secrecy"), out var pulPersonalSecrecy);
            int.TryParse(archiveObject?.Attribute?.FindValue("other_secrecy"), out var otherSecrecy);

            if (secrecy >= 10 && visibility.secrecyVisibility == Visibility.Restrict)
                return true;
            if (pulPersonalSecrecy >= 10 && visibility.pulPersonalSecrecyVisibility == Visibility.Restrict)
                return true;
            if (otherSecrecy >= 10 && visibility.otherSecrecyVisibility == Visibility.Restrict)
                return true;
            return false;
        }

        private static DateTime? TryConvertDate(IipaxObject archiveObject, string name)
        {
            return string.IsNullOrWhiteSpace(archiveObject.Attribute.FindValue(name))
                ? null
                : (DateTime?)DateTime.Parse(archiveObject.Attribute.FindValue(name));
        }
    }

    public static class IipaxExtensions
    {
        public static string FindValue(this IEnumerable<NameValue> source, string value)
        {
            return source.FirstOrDefault(x => x.name == value)?.Value.FirstOrDefault() ?? "";
        }
    }
}
