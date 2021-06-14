using System;
using Reflex.Data.Models;
using VisaRService;

namespace Reflex.Services
{
    public interface IProxyService
    {
        public IVisaRService GetProxy(CaseSource source, Guid configId);
    }
}
