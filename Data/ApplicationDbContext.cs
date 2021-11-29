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
using Reflex.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
            var stringArrayConverter = new ValueConverter<string[], string>(
                v => JsonSerializer.Serialize(v, null),
                v => JsonSerializer.Deserialize<string[]>(v, null));

            var stringArrayComparer = new ValueComparer<string[]>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToArray());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Config>().Property(p => p.Tabs)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<List<Tab>>(v, null),
                    new ValueComparer<ICollection<Tab>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c));
            modelBuilder.Entity<Config>().Property(p => p.Map)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<List<string>>(v, null),
                    new ValueComparer<ICollection<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c));
            modelBuilder.Entity<ByggrConfig>().Property(p => p.Tabs)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<List<CaseTab>>(v, null),
                    new ValueComparer<ICollection<CaseTab>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c));
            modelBuilder.Entity<ByggrConfig>().Property(p => p.DocumentTypes)
                .HasConversion(stringArrayConverter, stringArrayComparer);
            modelBuilder.Entity<ByggrConfig>().Property(p => p.OccurenceTypes)
                .HasConversion(stringArrayConverter, stringArrayComparer);
            modelBuilder.Entity<ByggrConfig>().Property(p => p.PersonRoles)
                .HasConversion(stringArrayConverter, stringArrayComparer);
            modelBuilder.Entity<ByggrConfig>().Property(p => p.Diarieprefixes)
                .HasConversion(stringArrayConverter, stringArrayComparer);
            modelBuilder.Entity<IipaxConfig>().Property(p => p.ObjectTypes)
                .HasConversion(stringArrayConverter, stringArrayComparer);
            modelBuilder.Entity<AgsConfig>().Property(p => p.Password)
                .HasConversion(
                    v => Encrypt(v),
                    v => Decrypt(v));
            modelBuilder.Entity<ApplicationUser>().Property(p => p.DefaultTab)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<Tab>(v, null));
            modelBuilder.Entity<ByggrSettings>().Property(p => p.Password)
                .HasConversion(
                    v => Encrypt(v),
                    v => Decrypt(v));
            modelBuilder.Entity<EcosSettings>().Property(p => p.Password)
                .HasConversion(
                    v => Encrypt(v),
                    v => Decrypt(v));
            modelBuilder.Entity<FbSettings>().Property(p => p.FbServicePassword)
                .HasConversion(
                    v => Encrypt(v),
                    v => Decrypt(v));
        }

        public DbSet<Config> Configs { get; set; }
        public DbSet<AgsConfig> AgsConfigs { get; set; }
        public DbSet<ByggrConfig> ByggrConfigs { get; set; }
        public DbSet<EcosConfig> EcosConfigs { get; set; }
        public DbSet<IipaxConfig> IipaxConfigs { get; set; }
        public DbSet<AgsSettings> AgsSettings { get; set; }
        public DbSet<ByggrSettings> ByggrSettings { get; set; }
        public DbSet<EcosSettings> EcosSettings { get; set; }
        public DbSet<IipaxSettings> IipaxSettings { get; set; }
        public DbSet<FbSettings> FbSettings { get; set; }

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
