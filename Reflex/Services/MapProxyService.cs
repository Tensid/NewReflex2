using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Reflex.Services
{
    public class MapProxyService : IMapProxyService
    {
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _env;

        public MapProxyService(HttpClient httpClient, IWebHostEnvironment env)
        {
            _httpClient = httpClient;
            _env = env;
        }

        public async Task<Stream> ProxyRequest(string queryString, string id)
        {
            var file = Path.Combine(_env.ContentRootPath, "", "layers.json");
            var text = File.ReadAllText(file);
            var layers = JsonSerializer.Deserialize<Layer[]>(text, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var layer = layers.FirstOrDefault(x => x.Id == id);
            var username = layer?.Username;
            var password = layer?.Password;
            var url = layer?.EndPoint;

            url += queryString;

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            if (username != null && password != null)
            {
                var authenticationString = $"{username}:{password}";
                var base64EncodedAuthenticationString = Convert.ToBase64String(Encoding.UTF8.GetBytes(authenticationString));
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
            }

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStreamAsync();
            }

            return null;
        }
    }

    public class Layer
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Id { get; set; }
        public bool BaseLayer { get; set; }
        public string EndPoint { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public JsonElement Options { get; set; }
        public JsonElement TileGridOptions { get; set; }
    }
}
