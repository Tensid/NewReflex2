using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reflex.Data.Models;

namespace Reflex.Services
{
    public interface IRepository
    {
        public IEnumerable<Config> GetConfigs();
        public Config GetConfig(Guid id);
        void UpdateConfig(Config config);
        public void DeleteConfig(Guid id);
        Task CreateAgs(AgsConfig agsConfig);
        Task CreateByggr(ByggrConfig byggRConfig);
        Task CreateEcos(EcosConfig ecosConfig);
        Task CreateIipax(IipaxConfig ecosConfig);
    }
}
