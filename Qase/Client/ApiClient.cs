using NLog;
using RestSharp;
using Core.Utilities.Configuration;

namespace Core.Client
{
    public class ApiClient
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly RestClient _restClient;

        public ApiClient()
        {
            var options = new RestClientOptions(Configurator.AppSettings.ApiURL)
            {
                ThrowOnAnyError = false,
                MaxTimeout = 10000
            };

            _restClient = new RestClient(options);
            _restClient.AddDefaultHeader("accept", "application/json");
            _restClient.AddDefaultHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86"); // забрать Token из appsettings.json
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
