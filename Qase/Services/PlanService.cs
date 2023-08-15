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
    public  class PlanService : BaseService
    {
        public PlanService(ApiClient apiClient) : base(apiClient)
        {

        }

        //public Plan GetSuite(string code, int id)
        //{
        //    var request = new RestRequest(Endpoints.GET_SUITE)
        //        .AddUrlSegment("code", code)
        //        .AddUrlSegment("project_id", id);

        //    return _apiClient.Execute<Plan>(request);
        //}

        public Plan CreatePlan(Plan plan)
        {
            var request = new RestRequest(Endpoints.CREATE_PLAN, Method.Post)
                .AddUrlSegment("code", plan.Code)
                .AddHeader("accept", "application/json")
                .AddHeader("content-Type", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")                
                .AddBody(plan);

            return _apiClient.Execute<Plan>(request);
        }
    }
}
