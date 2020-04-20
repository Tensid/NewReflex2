using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using ArendeExportWS;
using VisaRService;
using VisaRService.Contracts;

namespace ReflexByggrService
{
    public class ByggrService : IVisaRService
    {
        private readonly ConfigItem _config;
        public ByggrService(ConfigItem config)
        {
            _config = config;
        }

        private static ExportArendenClient GetExportArendenClient(string serviceUrl)
        {
            Binding binding = new BasicHttpBinding
            {
                MaxReceivedMessageSize = int.MaxValue
            };

            var uri = serviceUrl;
            var address = new EndpointAddress(uri);
            var client = new ExportArendenClient(binding, address);

            return client;
        }

        public ArchivedDocument[] GetArchivedDocumentsByCase(string caseId)
        {
            throw new NotImplementedException();
        }

        public Case[] GetCasesByEstate(string estateId)
        {
            var client = GetExportArendenClient(_config.ByggrConfig.ServiceUrl);
            var arenden = client.GetRelateradeArendenByFastighetAsync(Convert.ToInt32(estateId), null, null, null, StatusFilter.None).Result.GetRelateradeArendenByFastighetResult;
            client.CloseAsync();

            var hideByComment = !string.IsNullOrWhiteSpace(_config.ByggrConfig.HideDocumentsWithCommentMatching);

            var cases = arenden
                .Where(x => _config.ByggrConfig.OnlyCasesWithoutMainDecision == false || !x.handelseLista.Any(h => h.beslut.arHuvudbeslut))
                .Where(x => _config.ByggrConfig.MinCaseStartDate == null || x.ankomstDatum > _config.ByggrConfig.MinCaseStartDate)
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
                    Date = arende.ankomstDatum,
                    UnavailableDueToSecrecy = _config.ByggrConfig.HideCasesWithSecretOccurences && arende.handelseLista.Any(x => x.sekretess)
                }).ToArray();

            return cases;
        }

        public Estate[] GetEstatesByCase(string caseId)
        {
            ExportArendenClient client = GetExportArendenClient(_config.ByggrConfig.ServiceUrl);
            ArrayOfArendeFastighetArendeFastighet[] fastighetLista;
            try
            {
                fastighetLista = client.GetArendeAsync(caseId).Result.fastighetLista;
            }

            catch (Exception)
            {
                return new Estate[] { };
            }

            return fastighetLista.Select(e => new Estate { EstateId = e.fnr.ToString(), EstateName = e.fastighetsbeteckning }).ToArray();
        }

        public async Task<PhysicalDocument> GetDocument(string id)
        {
            var client = GetExportArendenClient(_config.ByggrConfig.ServiceUrl);
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

        public Occurence[] GetOccurencesByCase(string caseId)
        {
            throw new NotImplementedException();
        }

        public CasePerson[] GetPersonsByCase(string caseId)
        {
            throw new NotImplementedException();
        }

        public string GetPreviewByCase(string caseId)
        {
            throw new NotImplementedException();
        }
    }
}
