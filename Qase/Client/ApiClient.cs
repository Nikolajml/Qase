﻿using NLog;
using RestSharp;
using Core.Utilities.Configuration;
using System.Net.Mime;

namespace Core.Client
{
    public class ApiClient
    {
        protected readonly Logger _logger;
        private readonly RestClient _restClient;

        public ApiClient(string token = null)
        {
            _logger = LogManager.GetCurrentClassLogger();

            var options = new RestClientOptions(new Configurator().AppSettings.ApiURL)
            {
                ThrowOnAnyError = false,
                MaxTimeout = 10000
            };

            _restClient = new RestClient(options);
            _restClient.AddDefaultHeader("accept", "application/json");

            if (token != null)
            {
                _restClient.AddDefaultHeader("Token", token);
            }
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
