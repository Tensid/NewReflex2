using Reflex.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Text.Json;

namespace Reflex.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options,
           IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Config>().Property(p => p.CaseSources)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<List<CaseSource>>(v, null));
            modelBuilder.Entity<Config>().Property(p => p.Tabs)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<List<Tab>>(v, null));
            modelBuilder.Entity<ByggrConfig>().Property(p => p.Tabs)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<List<CaseTab>>(v, null));
            modelBuilder.Entity<ByggrConfig>().Property(p => p.DocumentTypes)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<string[]>(v, null));
            modelBuilder.Entity<ByggrConfig>().Property(p => p.OccurenceTypes)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<string[]>(v, null));
            modelBuilder.Entity<ByggrConfig>().Property(p => p.PersonRoles)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<string[]>(v, null));
        }

        public DbSet<Config> Configs { get; set; }
        public DbSet<AgsConfig> AgsConfigs { get; set; }
        public DbSet<ByggrConfig> ByggrConfigs { get; set; }
        public DbSet<EcosConfig> EcosConfigs { get; set; }
        public DbSet<DefaultConfig> DefaultConfig { get; set; }
    }
}
