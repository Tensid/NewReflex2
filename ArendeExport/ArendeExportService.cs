using ArendeExportWS;
using Reflex.Data;
using Reflex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.ServiceModel;

namespace ArendeExport
{
    public class ArendeExportService
    {
        private readonly ByggrSettings? _settings;
        private readonly ApplicationDbContext _context;

        public ArendeExportService(ApplicationDbContext context)
        {
            _settings = context.ByggrSettings.FirstOrDefault();
            _context = context;
        }

        public ExportArendenClient? GetExportArendenClient()
        {
            var uri = _settings?.ServiceUrl;
            if (uri == null)
                return null;

            var binding = new BasicHttpBinding
            {
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue
            };

            if (uri.StartsWith("https:"))
            {
                if (!string.IsNullOrEmpty(_settings?.Username) && !string.IsNullOrEmpty(_settings.Password))
                {
                    binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
                }
                else
                {
                    binding.Security.Mode = BasicHttpSecurityMode.Transport;
                }
            }

            var client = new ExportArendenClient(binding, new EndpointAddress(uri));
            if (string.IsNullOrEmpty(_settings?.Username) || string.IsNullOrEmpty(_settings.Password))
            {
                return client;
            }

            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            client.ClientCredentials.UserName.UserName = _settings.Username;
            client.ClientCredentials.UserName.Password = _settings.Password;

            return client;
        }
    }
}
