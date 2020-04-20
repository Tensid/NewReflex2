using System;
using System.Collections.Generic;
using FbService;
using Reflex.Models;
using VisaRService;

namespace Reflex.Data
{
    public interface IRepository
    {
        public IEnumerable<Config> GetConfigs();
        public Config GetConfig(Guid id);
        public IFbService GetFbProxy(Guid configId);
        public IVisaRService GetProxy(CaseSource source, Guid configId);
    }
}
