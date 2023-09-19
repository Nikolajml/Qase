using RestSharp;
using UI.Models;
using API.ResponseAPIModels;
using Core.Utilities;
using Core.Client;
using NLog;

namespace API.Services
{
    public class SuiteService
    {
        protected ApiClient _apiClient;
        protected ILogger _logger;

        public SuiteService(ILogger logger, ApiClient apiClient)
        {
            _apiClient = apiClient;

            _logger = logger;
        }


        public SuiteApiModel GetSuite_API(Suite suite)
        {
            var request = new RestRequest(Endpoints.GET_SUITE)
                .AddUrlSegment("code", suite.Code)
                .AddUrlSegment("id", suite.Id)
                .AddBody(suite);

            return _apiClient.Execute<SuiteApiModel>(request);
        }

        public SuiteApiModel CreateSuite_API(Suite suite)
        {
            var request = new RestRequest(Endpoints.CREATE_SUITE, Method.Post)
                .AddUrlSegment("code", suite.Code)
                .AddBody(suite);

            return _apiClient.Execute<SuiteApiModel>(request);
        }

        public SuiteApiModel UpdateSuite_API(Suite suite)
        {
            var request = new RestRequest(Endpoints.UPDATE_SUITE, Method.Patch)
                .AddUrlSegment("code", suite.Code)
                .AddUrlSegment("id", suite.Id)
                .AddBody(suite);

            return _apiClient.Execute<SuiteApiModel>(request);
        }

        public SuiteApiModel DeleteSuite_API(Suite suite)
        {
            var request = new RestRequest(Endpoints.DELETE_SUITE, Method.Delete)
                .AddUrlSegment("code", suite.Code)
                .AddUrlSegment("id", suite.Id)
                .AddBody(suite);

            return _apiClient.Execute<SuiteApiModel>(request);
        }
    }
}
