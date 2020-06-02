using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FbService;
using Reflex.Models;
using VisaRService;

namespace Reflex.Data
{
    public interface IRepository
    {
        public IEnumerable<Config> GetConfigs();
        public Config GetConfig(Guid id);
        public Task CreateConfig(Config config);
        void UpdateConfig(Config config);
        public void DeleteConfig(Guid id);
        Task CreateAgs(AgsConfig agsConfig);
        Task CreateByggr(ByggrConfig byggRConfig);
        Task CreateEcos(EcosConfig ecosConfig);
        public IFbService GetFbProxy(Guid configId);
        public IVisaRService GetProxy(CaseSource source, Guid configId);
    }
}
