using Qase.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Qase.Models;
using Qase.Utilities;

namespace Qase.Services
{
    public  class SuiteService : BaseService
    {
        public SuiteService(ApiClient apiClient) : base(apiClient)
        {
        }

        public Suite GetSuite(string code, int id)
        {
            var request = new RestRequest(Endpoints.GET_SUITE)
                .AddUrlSegment("code", code)
                .AddUrlSegment("project_id", id);

            return _apiClient.Execute<Suite>(request);
        }

        //public SuiteApiModel CreateSuite(Suite suite)
        //{
        //    var request = new RestRequest(Endpoints.CREATE_SUITE, Method.Post)
        //        .AddUrlSegment("code", suite.Code)
        //        .AddHeader("accept", "application/json")
        //        .AddHeader("content-Type", "application/json")
        //        .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
        //        .AddBody(suite);

        //    return _apiClient.Execute<SuiteApiModel>(request);
        //}
    }
}
