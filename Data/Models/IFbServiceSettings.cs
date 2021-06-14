namespace Reflex.Data.Models
{
    public interface IFbServiceSettings
    {
        string FbServiceDatabase { get; set; }
        string FbServicePassword { get; set; }
        string FbServiceUrl { get; set; }
        string FbServiceUser { get; set; }
    }
}
