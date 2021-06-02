using Reflex.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System;

namespace Reflex.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private readonly string _passwordHash = "UserP@55w0rd";
        private readonly string _saltKey = "S@17Sokigo123!";
        private readonly string _ivKey = "@1B2c3D4e5F6g7H8";

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
            modelBuilder.Entity<Config>().Property(p => p.FbServicePassword)
                .HasConversion(
                    v => Encrypt(v),
                    v => Decrypt(v));
            modelBuilder.Entity<AgsConfig>().Property(p => p.Password)
                .HasConversion(
                    v => Encrypt(v),
                    v => Decrypt(v));
            modelBuilder.Entity<EcosConfig>().Property(p => p.Password)
                .HasConversion(
                    v => Encrypt(v),
                    v => Decrypt(v));
            modelBuilder.Entity<ApplicationUser>().Property(p => p.DefaultTab)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<Tab>(v, null));
        }

        public DbSet<Config> Configs { get; set; }
        public DbSet<AgsConfig> AgsConfigs { get; set; }
        public DbSet<ByggrConfig> ByggrConfigs { get; set; }
        public DbSet<EcosConfig> EcosConfigs { get; set; }

        public string Encrypt(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
                return plainText;

            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            var keyBytes = new Rfc2898DeriveBytes(_passwordHash, Encoding.ASCII.GetBytes(_saltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(_ivKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public string Decrypt(string encryptedText)
        {
            if (string.IsNullOrWhiteSpace(encryptedText))
                return encryptedText;

            var cipherTextBytes = Convert.FromBase64String(encryptedText);
            var keyBytes = new Rfc2898DeriveBytes(_passwordHash, Encoding.ASCII.GetBytes(_saltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(_ivKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            var plainTextBytes = new byte[cipherTextBytes.Length];

            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    }
}
