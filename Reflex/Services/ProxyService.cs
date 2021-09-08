using Reflex.Data.Models;
using System;
using Microsoft.Extensions.Logging;
using VisaRService;
using ReflexAgsService;
using ReflexByggrService;
using ReflexEcosService;

namespace Reflex.Services
{
    public class ProxyService : IProxyService
    {
        private readonly ILogger _logger;
        private readonly AgsServiceFactory _agsServiceFactory;
        private readonly ByggrServiceFactory _byggrServiceFactory;
        private readonly EcosServiceFactory _ecosServiceFactory;

        public ProxyService(ILogger<ApplicationUser> logger, AgsServiceFactory agsServiceFactory, ByggrServiceFactory byggrServiceFactory, EcosServiceFactory ecosServiceFactory)
        {
            _logger = logger;
            _agsServiceFactory = agsServiceFactory;
            _byggrServiceFactory = byggrServiceFactory;
            _ecosServiceFactory = ecosServiceFactory;
        }

        public IVisaRService GetProxy(CaseSource caseSource, Guid id)
        {
            return caseSource switch
            {
                CaseSource.AGS => _agsServiceFactory.Create(id),
                CaseSource.ByggR => _byggrServiceFactory.Create(id),
                CaseSource.Ecos => _ecosServiceFactory.Create(id),
                _ => null
            };
        }
    }
}
