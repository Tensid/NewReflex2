using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Data.Models;

namespace Reflex.SettingsService
{
    public class SystemSettingsService : ISystemSettingsService
    {
        private readonly ILogger<SystemSettingsService> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SystemSettingsService(ILogger<SystemSettingsService> logger, ApplicationDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }

        public FbSettings GetFbSettings()
        {
            return _context.FbSettings.FirstOrDefault();
        }

        public FbWebbSettings GetFbWebbSettings()
        {
            //var settings = _context.FbSettings.FirstOrDefault() ?? new FbSettings();
            var settings = new FbSettings();
            return new FbWebbSettings
            {
                FbWebbBoendeUrl = settings.FbWebbBoendeUrl,
                FbWebbByggnadUrl = settings.FbWebbByggnadUrl,
                FbWebbByggnadUsrUrl = settings.FbWebbByggnadUsrUrl,
                FbWebbFastighetUrl = settings.FbWebbFastighetUrl,
                FbWebbFastighetUsrUrl = settings.FbWebbFastighetUsrUrl,
                FbWebbLagenhetUrl = settings.FbWebbLagenhetUrl
            };
        }

        public void UpdateFbSettings(FbSettings fbSettings)
        {
            _context.FbSettings.RemoveRange(_context.FbSettings);
            _context.FbSettings.Update(fbSettings);
            _context.SaveChanges();
        }

        public MiscSettings GetMiscSettings()
        {
            var file = Path.Combine(_env.ContentRootPath, "", "miscSettings.json");
            var text = File.ReadAllText(file);
            return JsonSerializer.Deserialize<MiscSettings>(text, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public async Task UpdateMiscSettings(MiscSettings miscSettings)
        {
            var file = Path.Combine(_env.ContentRootPath, "", "miscSettings.json");
            using FileStream createStream = File.Create(file);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            await JsonSerializer.SerializeAsync(createStream, miscSettings, options);
            await createStream.DisposeAsync();
        }

        public ByggrSettings GetByggrSettings()
        {
            return _context.ByggrSettings.FirstOrDefault();
        }

        public void UpdateByggrSettings(ByggrSettings settings)
        {
            _context.ByggrSettings.RemoveRange(_context.ByggrSettings);
            _context.ByggrSettings.Update(settings);
            _context.SaveChanges();
        }

        public AgsSettings GetAgsSettings()
        {
            return _context.AgsSettings.FirstOrDefault();
        }

        public void UpdateAgsSettings(AgsSettings settings)
        {
            _context.AgsSettings.RemoveRange(_context.AgsSettings);
            _context.AgsSettings.Update(settings);
            _context.SaveChanges();
        }

        public EcosSettings GetEcosSettings()
        {
            return _context.EcosSettings.FirstOrDefault();
        }

        public void UpdateEcosSettings(EcosSettings settings)
        {
            _context.EcosSettings.RemoveRange(_context.EcosSettings);
            _context.EcosSettings.Update(settings);
            _context.SaveChanges();
        }

        public IipaxSettings GetIipaxSettings()
        {
            return _context.IipaxSettings.FirstOrDefault();
        }

        public void UpdateIipaxSettings(IipaxSettings settings)
        {
            _context.IipaxSettings.RemoveRange(_context.IipaxSettings);
            _context.IipaxSettings.Update(settings);
            _context.SaveChanges();
        }
    }
}
