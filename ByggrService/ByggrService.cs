using System;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using ArendeExportWS;
using VisaRService;
using VisaRService.Contracts;
using Document = VisaRService.Contracts.Document;

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

        public Task<ArchivedDocument[]> GetArchivedDocumentsByCase(string caseId)
        {
            throw new NotImplementedException();
        }

        public async Task<Case[]> GetCasesByEstate(string estateId)
        {
            var client = GetExportArendenClient(_config.ByggrConfig.ServiceUrl);
            var arenden = (await client.GetRelateradeArendenByFastighetAsync(Convert.ToInt32(estateId), null, null, null, StatusFilter.None)).GetRelateradeArendenByFastighetResult;
            await client.CloseAsync();

            var hideByComment = !string.IsNullOrWhiteSpace(_config.ByggrConfig.HideDocumentsWithCommentMatching);

            var cases = arenden
                .Where(x => _config.ByggrConfig.OnlyCasesWithoutMainDecision == false || !x.handelseLista.Any(h => h.beslut?.arHuvudbeslut ?? false))
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

        public async Task<Case> GetCase(string id)
        {
            var client = GetExportArendenClient(_config.ByggrConfig.ServiceUrl);
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
                    CaseSource = "ByggR"
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Occurence[]> GetOccurencesByCase(string caseId)
        {
            var client = GetExportArendenClient(_config.ByggrConfig.ServiceUrl);
            var arende = client.GetArendeAsync(caseId).Result;
            await client.CloseAsync();

            var hideByComment = !string.IsNullOrWhiteSpace(_config.ByggrConfig.HideDocumentsWithCommentMatching);

            return arende.handelseLista
                .Where(handelse => _config.ByggrConfig.OccurenceTypes == null || !_config.ByggrConfig.OccurenceTypes.Any() || _config.ByggrConfig.OccurenceTypes.Contains(handelse.handelsetyp))
                .Where(handelse => !handelse.makulerad)
                .Where(handelse => _config.ByggrConfig.WorkingMaterial || handelse.arbetsmaterial == false)
                .Select(handelse => new Occurence
                {
                    Documents = handelse.sekretess ? new Document[0] : handelse.handlingLista
                        .Where(handling => (!_config.ByggrConfig?.DocumentTypes?.Any() ?? true) ||
                            (_config.ByggrConfig?.DocumentTypes?.Contains(handling.typ) ?? true))
                        .Where(handling => (_config.ByggrConfig?.WorkingMaterial ?? false) || !ContainsWorkingMaterial(handling.status))
                        .Select(handling => new Document
                        {
                            DocLinkId = (handling.docId == null ||
                                         (hideByComment &&
                                         (handelse.anteckning?.Contains(_config.ByggrConfig.HideDocumentsWithCommentMatching) ?? false))
                                ? "-1"
                                : handling.docId).ToString(CultureInfo.InvariantCulture),
                            Title = handling.docName ?? "Dokument (namn saknas)"
                        })
                        .ToArray(),
                    Arrival = handelse.startDatum,
                    Title = handelse.rubrik,
                    IsSecret = handelse.sekretess
                }).ToArray();
        }

        private static bool ContainsWorkingMaterial(string str)
        {
            var arbetsmaterial = new[] { "Arbetsmtrl", "Arbetsmaterial" };
            return arbetsmaterial.Any(a => str?.Contains(a) ?? false);
        }

        public async Task<CasePerson[]> GetPersonsByCase(string caseId)
        {
            var client = GetExportArendenClient(_config.ByggrConfig.ServiceUrl);
            var arende = client.GetArendeAsync(caseId).Result;
            await client.CloseAsync();

            var arenden = arende.intressentLista
                .Where(p => p.rollLista == null || _config.ByggrConfig.PersonRoles == null || !_config.ByggrConfig.PersonRoles.Any() || p.rollLista.Any(roll => _config.ByggrConfig.PersonRoles.Contains(roll)))
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
            var client = GetExportArendenClient(_config.ByggrConfig.ServiceUrl);
            var arende = await client.GetArendeAsync(caseId);

            var hideByComment = !string.IsNullOrWhiteSpace(_config.ByggrConfig.HideDocumentsWithCommentMatching);
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
                        .Where(p => p.rollLista == null || _config.ByggrConfig.PersonRoles == null || !_config.ByggrConfig.PersonRoles.Any() || p.rollLista.Any(roll => _config.ByggrConfig.PersonRoles.Contains(roll)))
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
                        .Where(handelse => _config.ByggrConfig.OccurenceTypes == null || !_config.ByggrConfig.OccurenceTypes.Any() || _config.ByggrConfig.OccurenceTypes.Contains(handelse.handelsetyp))
                        .Where(handelse => !handelse.makulerad)
                        .Where(handelse => _config.ByggrConfig.WorkingMaterial || handelse.arbetsmaterial == false)
                        .Select(handelse => new Handelse
                        {
                            Documents = handelse.sekretess ? new Document[0] : handelse.handlingLista
                                .Where(handling => !(_config.ByggrConfig?.DocumentTypes?.Any() ?? false) || _config.ByggrConfig.DocumentTypes.Contains(handling.typ))
                                .Where(handling => _config.ByggrConfig.WorkingMaterial || !ContainsWorkingMaterial(handling.status))
                                .Select(handling => new Document
                                {
                                    DocLinkId = (handling.docId == null || (hideByComment && (handelse.anteckning?.Contains(_config.ByggrConfig.HideDocumentsWithCommentMatching) ?? false)) ? "-1" : handling.docId).ToString(CultureInfo.InvariantCulture),
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
    }
}
