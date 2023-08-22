using NLog;
using RestSharp;
using API.ResponseAPIModels;
using UI.Models;
using Core.Utilities;
using Core.Client;

namespace API.Services
{
    public class CaseService : BaseService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CaseService(ApiClient apiClient) : base(apiClient)
        {

        }

        public CaseApiModel GetCase(Case Case)
        {
            var request = new RestRequest(Endpoints.GET_CASE)
                .AddUrlSegment("code", Case.Code)
                .AddUrlSegment("id", Case.Id)
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }

        public CaseApiModel CreateCase(Case Case)
        {
            var request = new RestRequest(Endpoints.CREATE_CASE, Method.Post)
                .AddUrlSegment("code", Case.Code)                
                .AddBody(Case);                        

            return _apiClient.Execute<CaseApiModel>(request); ;
        }

        public CaseApiModel UpdateCase(Case Case)
        {
            var request = new RestRequest(Endpoints.UPDATE_CASE, Method.Patch)
                .AddUrlSegment("code", Case.Code)
                .AddUrlSegment("id", Case.Id)
                .AddBody(new Case() { Title = Case.Title, Description = Case.Description});

            return _apiClient.Execute<CaseApiModel>(request);
        }

        public CaseApiModel DeleteCase(Case Case)
        {
            var request = new RestRequest(Endpoints.DELETE_CASE, Method.Delete)
                .AddUrlSegment("code", Case.Code)
                .AddUrlSegment("id", Case.Id)
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }
    }
}
