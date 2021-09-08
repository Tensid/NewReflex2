using System;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using ArendeExportWS;
using Reflex.Data;
using Reflex.Data.Models;
using VisaRService;
using VisaRService.Contracts;
using Document = VisaRService.Contracts.Document;

namespace ReflexByggrService
{
    public class ByggrServiceFactory
    {
        private readonly ByggrSettings _settings;
        private readonly ApplicationDbContext _context;

        public ByggrServiceFactory(ApplicationDbContext context)
        {
            _settings = context.ByggrSettings.FirstOrDefault();
            _context = context;
        }

        public ByggrService Create(Guid id)
        {
            var byggrConfig = _context.ByggrConfigs.FirstOrDefault(x => x.Id == id);
            return new ByggrService(_settings, byggrConfig);
        }
    }

    public class ByggrService : IVisaRService
    {
        private readonly ByggrSettings _settings;
        private readonly ByggrConfig _config;

        public ByggrService(ByggrSettings settings, ByggrConfig byggrConfig)
        {
            _settings = settings;
            _config = byggrConfig;
        }

        private ExportArendenClient GetExportArendenClient()
        {
            Binding binding = new BasicHttpBinding
            {
                MaxReceivedMessageSize = int.MaxValue
            };

            var uri = _settings.ServiceUrl;
            var address = new EndpointAddress(uri);
            var client = new ExportArendenClient(binding, address);

            return client;
        }

        public Task<ArchivedDocument[]> GetArchivedDocumentsByCase(string caseId)
        {
            throw new NotImplementedException();
        }

        public async Task<Case[]> GetCasesByEstate(string estateId)
        {
            var client = GetExportArendenClient();
            var arenden = client.GetRelateradeArendenByFastighetAsync(Convert.ToInt32(estateId), null, null, null,
                _config.OnlyActiveCases ? StatusFilter.Aktiv : StatusFilter.None).Result.GetRelateradeArendenByFastighetResult;
            await client.CloseAsync();

            var hideByComment = !string.IsNullOrWhiteSpace(_config.HideDocumentsWithCommentMatching);

            var cases = arenden.Where(x => _config.OnlyCasesWithoutMainDecision == false || x.handelseLista.All(h => !h.beslut?.arHuvudbeslut ?? true))
                .Where(x => _config.MinCaseStartDate == null || x.ankomstDatum > _config.MinCaseStartDate)
                .Where(x => _config.Diarieprefixes?.Any() != true || _config.Diarieprefixes.Contains(x.diarieprefix))
                .Select(arende => new Case
                {
                    Arendegrupp = arende.arendegrupp,
                    Arendeslag = arende.arendeslag,
                    Arendetyp = arende.arendetyp,
                    Status = arende.status.ToString(),
                    Fastighetsbeteckning = string.Join(", ", arende.fastighetLista.Select(x => x.fastighetsbeteckning)),
                    Kommun = arende.kommun,
                    Beskrivning = arende.beskrivning,
                    HandlaggareEfternamn = arende.handlaggare.efternamn,
                    HandlaggareFornamn = arende.handlaggare.fornamn,
                    HandlaggareSignatur = arende.handlaggare.signatur,
                    CaseId = arende.arendeId.ToString(),
                    Dnr = arende.dnr,
                    Title = arende.beskrivning,
                    CaseSource = "ByggR",
                    CaseSourceId = _config.Id,
                    Date = arende.ankomstDatum,
                    UnavailableDueToSecrecy = _config.HideCasesWithSecretOccurences && arende.handelseLista.Any(x => x.sekretess),
                    CaseWithoutMainDecision = arende.handelseLista.All(h => !h.beslut?.arHuvudbeslut ?? true),
                    Diarieprefix = arende.diarieprefix
                }).ToArray();

            return cases;
        }

        public async Task<Case> GetCase(string id)
        {
            var client = GetExportArendenClient();
            try
            {
                var arende = await client.GetArendeAsync(id);
                await client.CloseAsync();

                return new Case
                {
                    Beskrivning = arende?.beskrivning,
                    CaseId = arende?.dnr,
                    Dnr = arende?.dnr,
                    Title = arende?.beskrivning,
                    Fastighetsbeteckning = string.Join(", ", arende.fastighetLista.Select(x => x.fastighetsbeteckning)),
                    CaseSource = "ByggR",
                    CaseSourceId = _config.Id
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Occurence[]> GetOccurencesByCase(string caseId)
        {
            var client = GetExportArendenClient();
            var arende = client.GetArendeAsync(caseId).Result;
            var handlingTyper = client.GetHandlingTyperAsync(StatusFilter.None).Result;
            await client.CloseAsync();

            var hideByComment = !string.IsNullOrWhiteSpace(_config.HideDocumentsWithCommentMatching);

            return arende.handelseLista
                .Where(handelse => _config.OccurenceTypes?.Any() != true || _config.OccurenceTypes.Contains(handelse.handelsetyp))
                .Where(handelse => !handelse.makulerad)
                .Where(handelse => _config.WorkingMaterial || handelse.arbetsmaterial == false)
                .Select(handelse => new Occurence
                {
                    Documents = handelse.sekretess ? new Document[0] : handelse.handlingLista
                        .Where(handling => (!_config?.DocumentTypes?.Any() ?? true) ||
                            (_config?.DocumentTypes?.Contains(handling.typ) ?? true))
                        .Where(handling => (_config?.WorkingMaterial ?? false) || !ContainsWorkingMaterial(handling.status))
                        .Select(handling => new Document
                        {
                            DocLinkId = (handling.docId == null ||
                                         (hideByComment &&
                                         (handelse.anteckning?.Contains(_config.HideDocumentsWithCommentMatching) ?? false))
                                ? "-1"
                                : handling.docId).ToString(CultureInfo.InvariantCulture),
                            Title = handlingTyper.FirstOrDefault(x => x.Typ == handling.typ)?.Beskrivning ?? handling.docName ?? "Dokument (namn saknas)"
                        })
                        .ToArray(),
                    Arrival = handelse.startDatum,
                    Title = handelse.rubrik,
                    IsSecret = handelse.sekretess,
                    IsWorkingMaterial = handelse.arbetsmaterial
                }).ToArray();
        }

        private static bool ContainsWorkingMaterial(string str)
        {
            var arbetsmaterial = new[] { "Arbetsmtrl", "Arbetsmaterial" };
            return arbetsmaterial.Any(a => str?.Contains(a) ?? false);
        }

        public async Task<CasePerson[]> GetPersonsByCase(string caseId)
        {
            var client = GetExportArendenClient();
            var arende = client.GetArendeAsync(caseId).Result;
            await client.CloseAsync();

            var arenden = arende.intressentLista
                .Where(p => _config.PersonRoles?.Any() != true || p.rollLista == null || p.rollLista.Any(roll => _config.PersonRoles.Contains(roll)))
                .Select(p => new CasePerson
                {
                    FullName = p.namn,
                    Communication = p.intressentKommunikationLista?.Select(x => x.beskrivning).ToArray(),
                    Roles = p.rollLista,
                    Adress = p.adress,
                    Ort = p.ort,
                    PostNr = p.postNr
                }).ToArray();
            return arenden;
        }

        public async Task<Preview> GetPreviewByCase(string caseId)
        {
            var client = GetExportArendenClient();
            var arende = await client.GetArendeAsync(caseId);

            var hideByComment = !string.IsNullOrWhiteSpace(_config.HideDocumentsWithCommentMatching);
            var preview = new Preview
            {
                Arendegrupp = arende.arendegrupp,
                Arendeslag = arende.arendeslag,
                Arendetyp = arende.arendetyp,
                Status = arende.status.ToString(),
                HandlaggareEfternamn = arende.handlaggare.efternamn,
                HandlaggareFornamn = arende.handlaggare.fornamn,
                HandlaggareSignatur = arende.handlaggare.signatur,
                CaseId = arende.arendeId.ToString(),
                Dnr = arende.dnr,
                Fastighetsbeteckning = string.Join(", ", arende.fastighetLista.Select(x => x.fastighetsbeteckning)),
                Persons = arende.intressentLista
                        .Where(p => _config.PersonRoles?.Any() != true || p.rollLista == null || p.rollLista.Any(roll => _config.PersonRoles.Contains(roll)))
                        .Select(p => new CasePerson
                        {
                            FullName = p.namn,
                            Communication = p.intressentKommunikationLista?.Select(x => x.beskrivning).ToArray(),
                            Roles = p.rollLista,
                            Adress = p.adress,
                            Ort = p.ort,
                            PostNr = p.postNr
                        }).ToArray(),
                Handelser = arende.handelseLista
                        .Where(handelse => _config.OccurenceTypes?.Any() != true || _config.OccurenceTypes.Contains(handelse.handelsetyp))
                        .Where(handelse => !handelse.makulerad)
                        .Where(handelse => _config.WorkingMaterial || handelse.arbetsmaterial == false)
                        .Select(handelse => new Handelse
                        {
                            Documents = handelse.sekretess ? new Document[0] : handelse.handlingLista
                                .Where(handling => !(_config?.DocumentTypes?.Any() ?? false) || _config.DocumentTypes.Contains(handling.typ))
                                .Where(handling => _config.WorkingMaterial || !ContainsWorkingMaterial(handling.status))
                                .Select(handling => new Document
                                {
                                    DocLinkId = (handling.docId == null || (hideByComment && (handelse.anteckning?.Contains(_config.HideDocumentsWithCommentMatching) ?? false)) ? "-1" : handling.docId).ToString(CultureInfo.InvariantCulture),
                                    Title = handling.docName ?? "Dokument (namn saknas)"
                                }).ToArray(),
                            Arrival = handelse.startDatum,
                            Title = handelse.rubrik,
                            IsSecret = handelse.sekretess,
                            Anteckning = handelse.anteckning,
                            BeslutNr = handelse.beslut?.beslutNr,
                            BeslutsText = handelse.beslut?.beslutstext,
                            Handelsetyp = handelse.handelsetyp,
                            IsWorkingMaterial = handelse.arbetsmaterial
                        }).ToArray()
            };

            return preview;
        }

        public async Task<PhysicalDocument> GetDocument(string id)
        {
            var client = GetExportArendenClient();
            var doc = await client.GetDocumentAsync(id);

            var rdoc = new PhysicalDocument
            {
                Data = doc.DocumentBytes,
                Extension = doc.DocumentExtension,
                Id = doc.DocumentId,
                Filename = doc.DocumentId + "." + doc.DocumentExtension.ToLower()
            };

            return rdoc;
        }

        public Task<Case> SearchCase(string caseId)
        {
            throw new NotImplementedException();
        }
    }
}
