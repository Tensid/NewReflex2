using System.Collections.Generic;
using Reflex.Models;
using System.Linq;
using Reflex.Data;

namespace Reflex.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Config> GetConfigs()
        {
            return _context.Configs.ToList();
        }
    }
}
