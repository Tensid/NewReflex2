using System.Collections.Generic;
using Reflex.Models;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;
using FbService;
using VisaRService.Contracts;

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
            return _context.Configs.Where(x => x.Id == configId).Select(x =>
                 new ConfigItem
                 {
                     Name = x.Name,
                     FbServiceUrl = x.FbServiceUrl,
                     FbServiceDatabase = x.FbServiceDatabase,
                     FbServiceUser = x.FbServiceUser,
                     FbServicePassword = x.FbServicePassword
                 }
            ).First();
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
