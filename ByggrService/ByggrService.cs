﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using ArendeExportWS;
using CustomExtensions;
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
            var uri = _settings?.ServiceUrl;
            if (uri == null)
                return null;

            var binding = new BasicHttpBinding
            {
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue
            };

            if (uri.StartsWith("https:"))
            {
                if (!string.IsNullOrEmpty(_settings.Username) && !string.IsNullOrEmpty(_settings.Password))
                {
                    binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
                }
                else
                {
                    binding.Security.Mode = BasicHttpSecurityMode.Transport;
                }
            }

            var client = new ExportArendenClient(binding, new EndpointAddress(uri));
            if (string.IsNullOrEmpty(_settings.Username) || string.IsNullOrEmpty(_settings.Password))
            {
                return client;
            }

            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            client.ClientCredentials.UserName.UserName = _settings.Username;
            client.ClientCredentials.UserName.Password = _settings.Password;

            return client;
        }

        public Task<ArchivedDocument[]> GetArchivedDocumentsByCase(string caseId)
        {
            throw new NotImplementedException();
        }

        public async Task<Case[]> GetCasesByEstate(string estateId)
        {
            var client = GetExportArendenClient();
            var arenden = (await client.GetRelateradeArendenByFastighetAsync(Convert.ToInt32(estateId), null, null, null,
                _config.OnlyActiveCases ? StatusFilter.Aktiv : StatusFilter.None)).GetRelateradeArendenByFastighetResult;
            client.Close();

            var filteredArenden = FilterArenden(arenden);
            var filteredCases = filteredArenden.Select(arende => new Case
            {
                Arendegrupp = arende.arendegrupp,
                Arendeslag = arende.arendeslag,
                Arendetyp = arende.arendetyp,
                Status = arende.status.ToString(),
                Fastighetsbeteckning = GetFastighetsbeteckning(arende),
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
                CaseWithoutMainDecision = arende.handelseLista.All(h => !h.beslut?.arHuvudbeslut ?? true),
                Diarieprefix = arende.diarieprefix,
                Tabs = _config.Tabs?.Select(x => x.ToString())
            }).ToArray();

            return filteredCases;
        }

        public async Task<Case> GetCase(string id)
        {
            var client = GetExportArendenClient();
            try
            {
                var arende = await client.GetArendeAsync(id);
                client.Close();

                var arenden = new List<Arende>() { arende };
                var filteredArenden = FilterArenden(arenden);
                if (!filteredArenden.Any())
                    return null;

                return new Case
                {
                    Beskrivning = arende?.beskrivning,
                    CaseId = arende?.dnr,
                    Dnr = arende?.dnr,
                    Title = arende?.beskrivning,
                    Fastighetsbeteckning = GetFastighetsbeteckning(arende),
                    CaseSource = "ByggR",
                    CaseSourceId = _config.Id,
                    Tabs = _config.Tabs.Select(x => x.ToString())
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IEnumerable<Arende> FilterArenden(IEnumerable<Arende> arenden)
        {
            var filteredArenden = arenden.Where(x => _config.OnlyCasesWithoutMainDecision == false || x.handelseLista.All(h => !h.beslut?.arHuvudbeslut ?? true));
            filteredArenden = filteredArenden.Where(x => _config.MinCaseStartDate == null || x.ankomstDatum > _config.MinCaseStartDate);
            filteredArenden = filteredArenden.Where(x => _config.Diarieprefixes?.Any() != true || _config.Diarieprefixes.Contains(x.diarieprefix));
            filteredArenden = filteredArenden.Where(x => _config.Statuses.IsNullOrEmpty() || !_config.Statuses.Contains(x.status.ToString()));
            filteredArenden = filteredArenden.Where(x => _config.HideCasesWithTextMatching.IsNullOrEmpty() || _config.HideCasesWithTextMatching.All(h => !x.beskrivning.Contains(h, StringComparison.OrdinalIgnoreCase)));
            return filteredArenden;
        }

        public async Task<Occurence[]> GetOccurencesByCase(string caseId)
        {
            var client = GetExportArendenClient();
            var arende = await client.GetArendeAsync(caseId);
            var handlingTyper = await client.GetHandlingTyperAsync(StatusFilter.None);
            client.Close();

            return arende.handelseLista
                .Where(handelse => _config.OccurenceTypes.IsNullOrEmpty() || !_config.OccurenceTypes.Contains(handelse.handelsetyp))
                .Where(handelse => !handelse.makulerad)
                .Where(handelse => _config.WorkingMaterial || handelse.arbetsmaterial == false)
                .Where(handelse => !handelse.sekretess || _config.HideConfidentialOccurences != Visibility.Hide)
                .Where(handelse => _config.HideOccurencesWithTextMatching.IsNullOrEmpty() || _config.HideOccurencesWithTextMatching.All(text => !handelse.rubrik.Contains(text, StringComparison.OrdinalIgnoreCase)))
                .Select(handelse => new Occurence
                {
                    Documents = handelse.sekretess ? Array.Empty<Document>() : handelse.handlingLista
                        .Where(handling => _config.DocumentTypes.IsNullOrEmpty() || !_config.DocumentTypes.Contains(handling.typ))
                        .Where(handling => _config.WorkingMaterial || !ContainsWorkingMaterial(handling.status))
                        .Select(handling => new Document
                        {
                            DocLinkId = GetDocLinkId(handling),
                            Title = handlingTyper.FirstOrDefault(x => x.Typ == handling?.typ)?.Beskrivning ?? handling?.dokument?.dokId ?? "Dokument (namn saknas)"
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
            var arende = await client.GetArendeAsync(caseId);
            var roller = await client.GetRollerAsync(RollTyp.Intressent, StatusFilter.None);
            client.Close();

            var arenden = arende.intressentLista
                .Where(p => _config.PersonRoles.IsNullOrEmpty() || p.rollLista.IsNullOrEmpty() || p.rollLista.Any(roll => !_config.PersonRoles.Contains(roll)))
                .Select(p => new CasePerson
                {
                    FullName = p.namn,
                    Communication = p.intressentKommunikationLista?.Select(x => x.beskrivning).ToArray(),
                    Roles = p.rollLista?.Select(x => roller.FirstOrDefault(y => y.RollKod == x).Beskrivning).ToArray(),
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
            var handlingTyper = await client.GetHandlingTyperAsync(StatusFilter.None);
            var roller = await client.GetRollerAsync(RollTyp.Intressent, StatusFilter.None);

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
                Fastighetsbeteckning = GetFastighetsbeteckning(arende),
                Persons = arende.intressentLista
                        .Where(p => _config.PersonRoles.IsNullOrEmpty() || p.rollLista.IsNullOrEmpty() || p.rollLista.Any(roll => !_config.PersonRoles.Contains(roll)))
                        .Select(p => new CasePerson
                        {
                            FullName = p.namn,
                            Communication = p.intressentKommunikationLista?.Select(x => x.beskrivning).ToArray(),
                            Roles = p.rollLista?.Select(x => roller.FirstOrDefault(y => y.RollKod == x).Beskrivning).ToArray(),
                            Adress = p.adress,
                            Ort = p.ort,
                            PostNr = p.postNr
                        }).ToArray(),
                Handelser = arende.handelseLista
                        .Where(handelse => _config.OccurenceTypes.IsNullOrEmpty() || !_config.OccurenceTypes.Contains(handelse.handelsetyp))
                        .Where(handelse => !handelse.makulerad)
                        .Where(handelse => _config.WorkingMaterial || handelse.arbetsmaterial == false)
                        .Where(handelse => _config.HideOccurencesWithTextMatching.IsNullOrEmpty() || _config.HideOccurencesWithTextMatching.All(text => !handelse.rubrik.Contains(text, StringComparison.OrdinalIgnoreCase)))
                        .Where(x => !x.sekretess || _config.HideConfidentialOccurences != Visibility.Hide)
                        .Select(handelse => new Handelse
                        {
                            Documents = handelse.sekretess ? Array.Empty<Document>() : handelse.handlingLista
                                .Where(handling => _config.DocumentTypes.IsNullOrEmpty() || !_config.DocumentTypes.Contains(handling.typ))
                                .Where(handling => _config.WorkingMaterial || !ContainsWorkingMaterial(handling.status))
                                .Select(handling => new Document
                                {
                                    DocLinkId = GetDocLinkId(handling),
                                    Title = handlingTyper.FirstOrDefault(x => x.Typ == handling?.typ)?.Beskrivning ?? handling?.dokument?.namn ?? "Dokument (namn saknas)"
                                }).ToArray(),
                            Arrival = handelse.startDatum,
                            Title = handelse.rubrik,
                            IsSecret = handelse.sekretess,
                            Anteckning = _config.HideNotesInPreview ? "" : handelse.anteckning,
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
            var doc = (await client.GetDocumentAsync(id, true, "")).GetDocumentResult.FirstOrDefault();

            var rdoc = new PhysicalDocument
            {
                Data = doc?.fil.filBuffer,
                Extension = doc?.fil.filAndelse,
                Id = doc?.dokId,
                Filename = doc?.dokId + "." + doc?.fil.filAndelse?.ToLower() ?? ""
            };

            return rdoc;
        }

        public Task<Case> SearchCase(string caseId)
        {
            throw new NotImplementedException();
        }

        private string GetDocLinkId(handling handling)
        {
            if (handling?.dokument?.dokId == null)
                return "-1";

            var doNotHideByText = _config.HideDocumentsWithNoteTextMatching.IsNullOrEmpty();
            if (doNotHideByText || handling?.anteckning == null || !_config.HideDocumentsWithNoteTextMatching.Any(h => handling.anteckning.Contains(h, StringComparison.OrdinalIgnoreCase)))
                return handling.dokument.dokId.ToString(CultureInfo.InvariantCulture);

            return "-1";
        }

        private static string GetFastighetsbeteckning(arende arende)
        {
            return string.Join(", ", arende.objektLista.Select(x =>
            {
                if (x is arendeFastighet arendeFastighet)
                    return $"{arendeFastighet.fastighet.trakt} {arendeFastighet.fastighet.fbetNr}";
                if (x is arendeOmrade arendeOmrade)
                    return $"{arendeOmrade.omrade.beteckning}";
                return "";
            }));
        }

        public Task<List<Task<Case[]>>> SearchCases(string caseId)
        {
            throw new NotImplementedException();
        }

        public Task<HandlingTyp[]> GetDocumentTypes()
        {
            var client = GetExportArendenClient();
            if (client == null)
                return Task.FromResult(Array.Empty<HandlingTyp>());
            return client.GetHandlingTyperAsync(StatusFilter.None);
        }

        public Task<Roll[]> GetRoles()
        {
            var client = GetExportArendenClient();
            if (client == null)
                return Task.FromResult(Array.Empty<Roll>());
            return client.GetRollerAsync(RollTyp.Intressent, StatusFilter.None);
        }
    }
}
