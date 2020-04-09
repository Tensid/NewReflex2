using System;
using System.Collections.Generic;
using Reflex.Models;

namespace Reflex.Data
{
    public interface IRepository
    {
        public IEnumerable<Config> GetConfigs();
        public Config GetConfig(Guid id);
    }
}
