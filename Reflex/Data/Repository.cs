using System.Collections.Generic;
using Reflex.Models;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;
using FbService;
using VisaRService.Contracts;
using VisaRService;
using ReflexAgsService;
using ReflexByggrService;
using ReflexEcos2Service;
using AgsConfig = VisaRService.Contracts.AgsConfig;
using ByggrConfig = VisaRService.Contracts.ByggrConfig;
using EcosConfig = VisaRService.Contracts.EcosConfig;
using Microsoft.EntityFrameworkCore;

namespace Reflex.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public Repository(ApplicationDbContext context, ILogger<ApplicationUser> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Config> GetConfigs()
        {
            return _context.Configs.ToList();
        }

        public Config GetConfig(Guid id)
        {
            try
            {
                return _context.Configs.FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                _logger.LogWarning("Misslyckades att hämta config.");
                return null;
            }
        }

        private ConfigItem GetConfigItemByid(Guid configId)
        {
            var configItem = _context.Configs.Where(x => x.Id == configId).Include(x => x.AgsConfigs)
                .Include(x => x.ByggrConfigs).Include(x => x.EcosConfigs).ToList()
                .Select(x =>
                {
                    var agsConfig = x?.AgsConfigs?.FirstOrDefault() ?? new Models.AgsConfig();
                    var byggrConfig = x?.ByggrConfigs?.FirstOrDefault() ?? new Models.ByggrConfig();
                    var ecosConfig = x?.EcosConfigs?.FirstOrDefault() ?? new Models.EcosConfig();
                    return new ConfigItem
                    {
                        Name = x?.Name,
                        AgsConfig = new AgsConfig
                        {
                            Username = agsConfig.Username,
                            Password = agsConfig.Password,
                            Instance = agsConfig.Instance,
                            Department = agsConfig.Department,
                            SearchWay = agsConfig.SearchWay,
                            CasePattern = agsConfig.CasePattern,
                            DocumentPattern = agsConfig.DocumentPattern,
                            DateField = agsConfig.DateField,
                            EstateNameSearch = agsConfig.EstateNameSearch,
                            ServiceUrl = agsConfig.ServiceUrl
                        },
                        ByggrConfig = new ByggrConfig
                        {
                            DocumentTypes = byggrConfig.DocumentTypes,
                            OccurenceTypes = byggrConfig.OccurenceTypes,
                            PersonRoles = byggrConfig.PersonRoles,
                            WorkingMaterial = byggrConfig.WorkingMaterial,
                            HideCasesWithSecretOccurences = byggrConfig.HideCasesWithSecretOccurences,
                            HideDocumentsWithCommentMatching = byggrConfig.HideDocumentsWithCommentMatching,
                            OnlyCasesWithoutMainDecision = byggrConfig.OnlyCasesWithoutMainDecision,
                            MinCaseStartDate = byggrConfig.MinCaseStartDate,
                            ServiceUrl = byggrConfig.ServiceUrl
                        },
                        EcosConfig = new EcosConfig
                        {
                            ServiceUrl = ecosConfig.ServiceUrl,
                            Username = ecosConfig.Username,
                            Password = ecosConfig.Password,
                        },
                        FbServiceUrl = x?.FbServiceUrl,
                        FbServiceDatabase = x?.FbServiceDatabase,
                        FbServiceUser = x?.FbServiceUser,
                        FbServicePassword = x?.FbServicePassword
                    };
                }).First();
            return configItem;
        }

        public IVisaRService GetProxy(CaseSource caseSource, Guid configId)
        {
            var config = Guid.Empty != configId ? GetConfigItemByid(configId) : GetConfigItemByid(GetDefaultConfig().Id);

            return caseSource switch
            {
                CaseSource.AGS => new AgsService(config),
                CaseSource.ByggR => new ByggrService(config),
                CaseSource.Ecos => new ReflexEcos2Svc(config),
                _ => null
            };
        }

        public IFbService GetFbProxy(Guid configId)
        {
            var config = Guid.Empty != configId ? GetConfigItemByid(configId) : GetConfigItemByid(GetDefaultConfig().Id);
            return new FbService.FbService(config);
        }

        private Config GetDefaultConfig()
        {
            try
            {
                var defaultConfig = _context.DefaultConfig.FirstOrDefault();
                return _context.Configs.Find(defaultConfig.ConfigId);
            }
            catch
            {
                _logger.LogWarning("Misslyckades att hämta defaultConfig.");
                return null;
            }
        }
    }
}
