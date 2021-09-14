using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Reflex.Data.Models;
using Reflex.Data;

namespace Reflex.Services
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
                .Include(x => x.ByggrConfigs).Include(x => x.EcosConfigs).Include(x => x.IipaxConfigs).ToList();
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

        public Task CreateAgs(AgsConfig agsConfig)
        {
            agsConfig.Id = Guid.NewGuid();
            _context.AddAsync(agsConfig);
            return _context.SaveChangesAsync();
        }

        public Task CreateByggr(ByggrConfig byggrConfig)
        {
            byggrConfig.Id = Guid.NewGuid();
            _context.Add(byggrConfig);
            return _context.SaveChangesAsync();
        }

        public Task CreateEcos(EcosConfig ecosConfig)
        {
            ecosConfig.Id = Guid.NewGuid();
            _context.Add(ecosConfig);
            return _context.SaveChangesAsync();
        }

        public Task CreateIipax(IipaxConfig iipaxConfig)
        {
            iipaxConfig.Id = Guid.NewGuid();
            _context.Add(iipaxConfig);
            return _context.SaveChangesAsync();
        }

        public void CreateConfig(Config config)
        {
            try
            {
                _context.Configs.Add(config);
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
    }
}
