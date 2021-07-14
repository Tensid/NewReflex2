using System.IO;
using System.Threading.Tasks;

namespace Reflex.Services
{
    public interface IMapProxyService
    {
        Task<Stream> ProxyRequest(string queryString, string id);
    }
}
