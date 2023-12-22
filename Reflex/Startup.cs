using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System;
using System.Linq;
using Reflex.Services;
using FbService;
using FbService.Provider;
using Reflex.Data.Models;
using Reflex.Data;
using Reflex.SettingsService;
using ReflexAgsService;
using ReflexByggrService;
using ReflexEcosService;
using Microsoft.AspNetCore.Authorization;
using ReflexIipaxService;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

namespace Reflex
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = Configuration.GetValue<bool>("RequireConfirmedAccount"))
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentityServer()
            //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
            //    .AddProfileService<ProfileService>();

            services.AddTransient<IRepository, Repository>();
            services.AddTransient<ISystemSettingsService, SystemSettingsService>();
            services.AddTransient<IProxyService, ProxyService>();
            services.AddTransient<AgsServiceFactory, AgsServiceFactory>();
            services.AddTransient<ByggrServiceFactory, ByggrServiceFactory>();
            services.AddTransient<EcosServiceFactory, EcosServiceFactory>();
            services.AddTransient<IipaxServiceFactory, IipaxServiceFactory>();
            services.AddTransient<IFbProvider, FbProvider>();
            services.AddTransient<IFbService, FbService.FbService>();
            services.AddTransient<IMapProxyService, MapProxyService>();

            services.AddHttpClient<IFbProvider, FbProvider>();

            //services.AddAuthentication()
            //    .AddWsFederation(options =>
            //    {
            //        options.MetadataAddress = Configuration["WsFederation:MetadataAddress"];
            //        options.Wtrealm = Configuration["WsFederation:Wtrealm"];
            //    })
            //    .AddIdentityServerJwt();

            //services.AddControllersWithViews();
            //services.AddRazorPages();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.HasConfigPermission, policy =>
                    policy.Requirements.Add(new HasConfigPermissionRequirement()));
            });
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy(Policies.HasCaseSourcePermission, policy =>
            //        policy.Requirements.Add(new HasCaseSourcePermissionRequirement()));
            //});
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.IsAdmin, policy =>
                    policy.Requirements.Add(new IsAdminRequirement()));
            });

            //options.AddPolicy(Policies.IsAdmin,
            //        policy => policy.RequireClaim(Permissions.IsAdmin, "True"));
            //services.AddScoped<IAuthorizationHandler, HasConfigPermissionHandler>();
            //services.AddScoped<IAuthorizationHandler, HasCaseSourcePermissionHandler>();
            services.AddScoped<IAuthorizationHandler, IsAdminHandler>();

            services.AddTransient<IEmailSender, EmailSender>(i =>
                new EmailSender(
                    Configuration["EmailSender:Host"],
                    Configuration.GetValue<int>("EmailSender:Port"),
                    Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    Configuration["EmailSender:UserName"],
                    Configuration["EmailSender:Password"]
                )
            );

            services.AddApplication<ReflexApplication>()
                .AddPermissions(Permissions.IsAdmin)
                .AddPermissions(Permissions.HasConfigPermission)
                .AddPermissions(Permissions.HasCaseSourcePermission)
                .AddSettings();
            services.AddApplication("user-settings");
            //services.AddApplication("help");
            //services.AddApplication("loading-indicator");

            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.AllowSynchronousIO = true;
            //});


            //services.AddControllers(options =>
            //{
            //    // Add the filter globally
            //    options.Filters.Add<UseSystemTextJsonActionFilter>();
            //}).AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //    options.JsonSerializerOptions.WriteIndented = true;
            //});

            //services.AddControllers(options => options.OutputFormatters.RemoveType<NewtonsoftJsonOutputFormatter>());

            //services.AddControllers().
            //AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //    options.JsonSerializerOptions.WriteIndented = true;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            //using var scope = host.Services.CreateScope();
            //var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }

        }
    }
}
