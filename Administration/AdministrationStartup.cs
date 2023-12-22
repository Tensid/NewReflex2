using Microsoft.Extensions.DependencyInjection;
using Sokigo.SBWebb.Core;

namespace Administration
{
    public class AdministrationStartup : IConfigureServices
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<AdministrationApplication>();
        }
    }
}
