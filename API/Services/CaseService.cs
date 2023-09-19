using NLog;
using RestSharp;
using API.ResponseAPIModels;
using UI.Models;
using Core.Utilities;
using Core.Client;

namespace API.Services
{
    public class CaseService
    {
        protected ApiClient _apiClient;
        protected ILogger _logger;

        public CaseService(ILogger logger, ApiClient apiClient)
        {
            _apiClient = apiClient;

            _logger = logger;
        }

        public CaseApiModel GetCase_API(Case Case)
        {
            var request = new RestRequest(Endpoints.GET_CASE)
                .AddUrlSegment("code", Case.Code)
                .AddUrlSegment("id", Case.Id)
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }

        public GetAllTestCase GetAllCase_API(string code)
        {
            var request = new RestRequest(Endpoints.GET_ALL_CASE)
                .AddUrlSegment("code", code)
                .AddParameter("limit", 99);

            return _apiClient.Execute<GetAllTestCase>(request);
        }

        public CaseApiModel CreateCase_API(Case Case)
        {
            var request = new RestRequest(Endpoints.CREATE_CASE, Method.Post)
                .AddUrlSegment("code", Case.Code)
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }

        public CaseApiModel UpdateCase_API(Case Case)
        {
            var request = new RestRequest(Endpoints.UPDATE_CASE, Method.Patch)
                .AddUrlSegment("code", Case.Code)
                .AddUrlSegment("id", Case.Id)
                .AddBody(new Case() { Title = Case.Title, Description = Case.Description });

            return _apiClient.Execute<CaseApiModel>(request);
        }

        public CaseApiModel DeleteCase_API(Case Case)
        {
            var request = new RestRequest(Endpoints.DELETE_CASE, Method.Delete)
                .AddUrlSegment("code", Case.Code)
                .AddUrlSegment("id", Case.Id)
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }
    }
}
