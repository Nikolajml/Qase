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

        public Suite CreateSuite(Suite suite)
        {
            var request = new RestRequest(Endpoints.CREATE_SUITE, Method.Post)
                .AddUrlSegment("code", suite.Code)
                .AddHeader("Content-Type", "application/json")
                .AddBody(suite.Name);

            return _apiClient.Execute<Suite>(request);
        }
    }
}
