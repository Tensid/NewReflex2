using System.Collections.Generic;
using Reflex.Models;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;

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
    }
}
