using NLog;
using Qase.ResponseAPIModels;
using Qase.Client;
using Qase.Models;
using Qase.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Services
{
    public  class CaseService : BaseService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CaseService(ApiClient apiClient) : base(apiClient)
        {

        }

        public CaseApiModel GetCase(Case Case, string id)
        {
            var request = new RestRequest(Endpoints.GET_CASE)
                .AddUrlSegment("code", Case.Code)
                .AddUrlSegment("id", id)
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }

        public CaseApiModel CreateCase(Case Case)
        {
            var request = new RestRequest(Endpoints.CREATE_CASE, Method.Post)
                .AddUrlSegment("code", Case.Code)
                .AddHeader("accept", "application/json")                
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(Case);

                return _apiClient.Execute<CaseApiModel>(request);
        }

        public CaseApiModel UpdateCase(Case Case, string id)
        {
            var request = new RestRequest(Endpoints.UPDATE_CASE, Method.Patch)
                .AddUrlSegment("code", Case.Code)
                .AddUrlSegment("id", id)
                .AddHeader("content-type", "application/json")
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }

        public CaseApiModel DeleteSuite(Case Case, string id)
        {
            var request = new RestRequest(Endpoints.DELETE_CASE, Method.Delete)
                .AddUrlSegment("code", Case.Code)
                .AddUrlSegment("id", id)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(Case);

            return _apiClient.Execute<CaseApiModel>(request);
        }
    }
}
