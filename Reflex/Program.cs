using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Models;

namespace Reflex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                Initialize(services);

            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            if (!context.Configs.Any())
            {
                context.Configs.AddRange(
                    new Config
                    {
                        Id = Guid.Parse("bbc09b80-11b0-4f55-9f6d-6690d422aa40"),
                        Name = "Allt",
                        Description = "En beskrivning",
                        Visible = true,
                        CaseSources = new[] { CaseSource.AGS, CaseSource.ByggR, CaseSource.Ecos },
                        Tabs = new[] { Tab.Cases, Tab.Map, Tab.Population, Tab.Property },
                    },
                    new Config
                    {
                        Id = Guid.Parse("9b27dd8f-50d0-420f-b169-74c5a018f829"),
                        Name = "Test",
                        Description = "En testkonfiguration",
                        Visible = true,
                        CaseSources = new[] { CaseSource.Ecos },
                        Tabs = new[] { Tab.Cases, Tab.Property },
                    }
                );

                context.SaveChanges();
            }

            if (!context.DefaultConfig.Any())
            {
                context.DefaultConfig.Add(new DefaultConfig { ConfigId = Guid.Parse("bbc09b80-11b0-4f55-9f6d-6690d422aa40") });
                context.SaveChanges();
            }
        }

    }
}
