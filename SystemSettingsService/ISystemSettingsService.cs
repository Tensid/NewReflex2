using Reflex.Data.Models;
using System.Threading.Tasks;

namespace Reflex.SettingsService
{
    public class MiscSettings
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string CsmUrl { get; set; }
    }

    public interface ISystemSettingsService
    {
        AgsSettings GetAgsSettings();
        ByggrSettings GetByggrSettings();
        EcosSettings GetEcosSettings();
        FbSettings GetFbSettings();
        FbWebbSettings GetFbWebbSettings();
        MiscSettings GetMiscSettings();
        IipaxSettings GetIipaxSettings();
        void UpdateAgsSettings(AgsSettings settings);
        void UpdateByggrSettings(ByggrSettings settings);
        void UpdateEcosSettings(EcosSettings settings);
        void UpdateIipaxSettings(IipaxSettings settings);
        void UpdateFbSettings(FbSettings fbSettings);
        Task UpdateMiscSettings(MiscSettings miscSettings);
    }
}