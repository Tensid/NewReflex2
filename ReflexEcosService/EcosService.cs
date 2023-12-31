﻿using CustomExtensions;
using EcosService;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VisaRService;
using VisaRService.Contracts;

namespace ReflexEcosService
{
    public class EcosServiceFactory
    {
        private readonly EcosSettings _settings;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EcosServiceFactory> _logger;

        public EcosServiceFactory(ApplicationDbContext context, ILogger<EcosServiceFactory> logger)
        {
            _settings = context.EcosSettings.FirstOrDefault();
            _context = context;
            _logger = logger;
        }

        public ReflexEcosSvc Create(Guid id)
        {
            var ecosConfig = _context.EcosConfigs.FirstOrDefault(x => x.Id == id);
            return new ReflexEcosSvc(_settings, ecosConfig, _logger);
        }
    }

    public class ReflexEcosSvc : IVisaRService
    {
        private readonly EcosSettings _settings;
        private readonly EcosConfig _config;
        private readonly ILogger _logger;

        public ReflexEcosSvc(EcosSettings settings, EcosConfig ecosConfig, ILogger logger)
        {
            _settings = settings;
            _config = ecosConfig;
            _logger = logger;
        }

        private ReflexServiceClient GetClient()
        {
            var binding = new BasicHttpBinding
            {
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
                Security =
                {
                    Mode =
                        _settings.ServiceUrl.StartsWith("https:")
                            ? BasicHttpSecurityMode.Transport
                            : BasicHttpSecurityMode.TransportCredentialOnly,
                    Transport = {ClientCredentialType = HttpClientCredentialType.Ntlm}
                }
            };
            var client = new ReflexServiceClient(binding, new EndpointAddress(_settings.ServiceUrl));
            if (string.IsNullOrEmpty(_settings.Username) || string.IsNullOrEmpty(_settings.Password))
            {
                return client;
            }
            client.ClientCredentials.Windows.ClientCredential.UserName = _settings.Username;
            client.ClientCredentials.Windows.ClientCredential.Password = _settings.Password;

            return client;
        }

        public async Task<Case[]> GetCasesByEstate(string estateId)
        {
            try
            {
                var client = GetClient();
                var searchCaseResults = await client.SearchCaseAsync(new ReflexSearchCase
                {
                    Filters = new Filter[] { new FnrFilter { Fnr = int.Parse(estateId) } }
                });

                //Ärende är sekretessmarkerat i Ecos om CaseId är null
                return searchCaseResults?.Where(x => x.CaseId != null || _config.HideConfidentialCases != Visibility.Hide)
                    .Where(x => !_config.ProcessTypes.Any(p => x.ProcessTypeName.Contains(p)))
                    .Select(x => new Case
                    {
                        Beskrivning = x.CaseSubtitleFree,
                        CaseId = x.CaseId.ToString(),
                        Dnr = x.CaseNumber,
                        Fastighetsbeteckning = x.EstateDesignation,
                        Title = Regex.Replace(x.ProcessTypeName, $"{x.CaseNumber}  -", ""),
                        CaseSource = "Ecos",
                        CaseSourceId = _config.Id,
                        UnavailableDueToSecrecy = x.CaseId == null
                    }).ToArray();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public async Task<Occurence[]> GetOccurencesByCase(string caseId)
        {
            try
            {
                var allowedDocumentStatuses = new[] { "Upprättad", "Inkommen" };

                var client = GetClient();
                var fullCase = await client.GetCaseAsync(Guid.Parse(caseId));
                return fullCase?.Occurrences.Where(x => _config.OccurrenceTypes.IsNullOrEmpty() || !_config.OccurrenceTypes.Contains(x.OccurrenceTypeId))
                    .Select(o => new Occurence
                    {
                        Title = o.OccurrenceDescription,
                        Arrival = o.OccurrenceDate,
                        IsSecret = o.IsConfidential,
                        Documents = o.Documents
                        .Where(x => allowedDocumentStatuses.Contains(x.DocumentStatus) && (!x.IsConfidential || _config.HideConfidentialDocuments != Visibility.Hide))
                        .Where(x => _config.DocumentTypes.IsNullOrEmpty() || !_config.DocumentTypes.Contains(x.DocumentTypeId))
                        .Select(d => new Document
                        {
                            Title = d.DocumentClassificationTypeDescription,
                            DocLinkId = (d.IsConfidential && _config.HideConfidentialDocuments == Visibility.Restrict || d.Filename == null) ? "-1" : d.DocumentId.ToString(),
                            IsConfidential = d.IsConfidential
                        }).ToArray()
                    }).ToArray();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public async Task<PhysicalDocument> GetDocument(string documentId)
        {
            var client = GetClient();
            var file = await client.GetDocumentFileAsync(Guid.Parse(documentId));

            return new PhysicalDocument
            {
                Data = file.Data,
                Filename = file.Filename
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

        public Task<ArchivedDocument[]> GetArchivedDocumentsByCase(string caseId)
        {
            return null;
        }

        public async Task<Case> GetCase(string caseId)
        {
            try
            {
                var result = Guid.TryParse(caseId, out Guid parsedCaseId);
                if (!result)
                    return await SearchConfidentialCase(caseId);

                var client = GetClient();
                var fullCase = await client.GetCaseAsync(parsedCaseId);
                if (fullCase == null)
                    return null;
                if (_config.ProcessTypes.Contains(fullCase.ProcessTypeName))
                    return null;

                return new Case
                {
                    Beskrivning = fullCase.CaseSubtitleFree,
                    CaseId = fullCase.CaseId.ToString(),
                    Dnr = fullCase.CaseNumber,
                    Fastighetsbeteckning = fullCase.EstateDesignation,
                    Title = string.Join(" - ",
                        new[] { fullCase.ProcessTypeName, fullCase.CaseSubtitle, fullCase.CaseSubtitleFree }.Where(s => !string.IsNullOrEmpty(s))),
                    CaseSource = "Ecos",
                    CaseSourceId = _config.Id
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        private async Task<Case> SearchConfidentialCase(string caseNumber)
        {
            try
            {
                if (_config.HideConfidentialCases == Visibility.Hide)
                    return null;

                var client = GetClient();
                var searchResult = (await client.SearchCaseAsync(new ReflexSearchCase
                {
                    Filters = new Filter[] { new CaseNumberFilter { CaseNumber = caseNumber } }
                })).FirstOrDefault();
                if (searchResult == null)
                    return null;
                if (_config.ProcessTypes.Any(p => searchResult.ProcessTypeName.Contains(p)))
                    return null;

                return new Case
                {
                    Beskrivning = searchResult.CaseSubtitleFree,
                    CaseId = searchResult.CaseId.ToString(),
                    Dnr = searchResult.CaseNumber,
                    Fastighetsbeteckning = searchResult.EstateDesignation,
                    Title = Regex.Replace(searchResult.ProcessTypeName, $"{searchResult.CaseNumber}  -", ""),
                    CaseSource = "Ecos",
                    CaseSourceId = _config.Id,
                    UnavailableDueToSecrecy = true
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public async Task<Case> SearchCase(string caseNumber)
        {
            try
            {
                var client = GetClient();
                var searchResult = (await client.SearchCaseAsync(new ReflexSearchCase
                {
                    Filters = new Filter[] { new CaseNumberFilter { CaseNumber = caseNumber } }
                })).FirstOrDefault();
                if (searchResult == null)
                    return null;
                if (searchResult.CaseId == null && _config.HideConfidentialCases == Visibility.Hide)
                    return null;
                if (_config.ProcessTypes.Any(p => searchResult.ProcessTypeName.Contains(p)))
                    return null;

                return new Case
                {
                    Beskrivning = searchResult.CaseSubtitleFree,
                    CaseId = searchResult.CaseId != null ? searchResult.CaseId.ToString() : Guid.Empty.ToString(),
                    Dnr = searchResult.CaseNumber,
                    Fastighetsbeteckning = searchResult?.EstateDesignation,
                    CaseSource = "Ecos",
                    CaseSourceId = _config.Id,
                    UnavailableDueToSecrecy = searchResult.CaseId == null
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public Task<List<Task<Case[]>>> SearchCases(string caseId)
        {
            throw new NotImplementedException();
        }
    }
}
