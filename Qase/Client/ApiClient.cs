using NLog;
using Qase.Utilities.Configuration;
using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Authenticators.OAuth2;
using Newtonsoft.Json.Linq;

namespace Qase.Client
{
    public class ApiClient
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly RestClient _restClient;

        public ApiClient()
        {
            var options = new RestClientOptions(Configurator.AppSettings.ApiURL)
            {    
                ThrowOnAnyError = true,
                MaxTimeout = 10000
            };

            _restClient = new RestClient(options);
        }

        public RestResponse Execute(RestRequest request)
        {
            _logger.Info("Request: " + request.Resource);
            var response = _restClient.Execute(request);

            _logger.Info("Response Status: " + response.ResponseStatus);
            _logger.Info("Response Body: " + response.Content);

            return response;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            _logger.Info("Request: " + request.Resource);
            var response = _restClient.Execute<T>(request);

            _logger.Info("Response Status: " + response.ResponseStatus);
            _logger.Info("Response Body: " + response.Content);

            return response.Data;
        }
    }
}
