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
using System.Threading.Tasks;

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
            return _context.Configs.Include(x => x.AgsConfigs)
                .Include(x => x.ByggrConfigs).Include(x => x.EcosConfigs).ToList();
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

        public Task CreateAgs(Models.AgsConfig agsConfig)
        {
            agsConfig.Id = Guid.NewGuid();
            _context.AddAsync(agsConfig);
            return _context.SaveChangesAsync();
        }

        public Task CreateByggr(Models.ByggrConfig byggrConfig)
        {
            byggrConfig.Id = Guid.NewGuid();
            _context.Add(byggrConfig);
            return _context.SaveChangesAsync();
        }

        public Task CreateEcos(Models.EcosConfig ecosConfig)
        {
            ecosConfig.Id = Guid.NewGuid();
            _context.Add(ecosConfig);
            return _context.SaveChangesAsync();
        }

        public async Task CreateConfig(Config config)
        {
            try
            {
                _context.Configs.Add(config);
                foreach (var caseSource in config.CaseSources)
                {
                    if (caseSource == CaseSource.AGS)
                    {
                        var agsConfig = await _context.AgsConfigs.SingleOrDefaultAsync(m => m.ConfigId == config.Id);
                        if (agsConfig == null)
                        {
                            await CreateAgs(new Models.AgsConfig
                            {
                                Id = Guid.NewGuid(),
                                ConfigId = config.Id,
                            });
                            await _context.SaveChangesAsync();
                        }
                    }
                    if (caseSource == CaseSource.ByggR)
                    {
                        var byggrConfig = await _context.ByggrConfigs.SingleOrDefaultAsync(m => m.ConfigId == config.Id);
                        if (byggrConfig == null)
                        {
                            await CreateByggr(new Models.ByggrConfig
                            {
                                Id = Guid.NewGuid(),
                                ConfigId = config.Id,
                            });
                            await _context.SaveChangesAsync();
                        }
                    }
                    if (caseSource == CaseSource.Ecos)
                    {
                        var ecosConfig = await _context.EcosConfigs.SingleOrDefaultAsync(m => m.ConfigId == config.Id);
                        if (ecosConfig == null)
                        {
                            await CreateEcos(new Models.EcosConfig
                            {
                                Id = Guid.NewGuid(),
                                ConfigId = config.Id,
                            });
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                _context.SaveChanges();
            }
            catch
            {
                _logger.LogWarning("Misslyckades att skapa config.");
            }
        }

        public void DeleteConfig(Guid id)
        {
            try
            {
                var claims = _context.UserClaims.Where(x => x.ClaimValue == id.ToString());
                _context.UserClaims.RemoveRange(claims);

                var config = _context.Configs.FirstOrDefault(x => x.Id == id);
                _context.Configs.Remove(config);
                _context.SaveChanges();
            }
            catch
            {
                _logger.LogWarning("Misslyckades att ta bort config.");
            }
        }

        public void UpdateConfig(Config config)
        {
            try
            {
                _context.Configs.Update(config);
                _context.SaveChanges();
            }
            catch
            {
                _logger.LogWarning("Misslyckades att uppdatera config.");
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
            var config = GetConfigItemByid(configId);

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
            var config = GetConfigItemByid(configId);
            return new FbService.FbService(config);
        }
    }
}
