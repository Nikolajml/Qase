using BusinessObject.Models;
using BusinessObject.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using RestSharp;

namespace BusinessObject.Services
{
    public class PlanService : BaseService
    {
        public PlanService(ApiClient apiClient) : base(apiClient)
        {

        }

        public PlanApiModel GetPlan(Plan plan, string id)
        {
            var request = new RestRequest(Endpoints.GET_PLAN)
                .AddUrlSegment("code", plan.Code)
                .AddUrlSegment("id", id)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }

        public PlanApiModel CreatePlan(Plan plan)
        {
            var request = new RestRequest(Endpoints.CREATE_PLAN, Method.Post)
                .AddUrlSegment("code", plan.Code)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }

        public PlanApiModel UpdatePlan(Plan plan, string id)
        {
            var request = new RestRequest(Endpoints.UPDATE_PLAN, Method.Patch)
                .AddUrlSegment("code", plan.Code)
                .AddUrlSegment("id", id)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }

        public PlanApiModel DeletePlan(Plan plan, string id)
        {
            var request = new RestRequest(Endpoints.DELETE_PLAN, Method.Delete)
                .AddUrlSegment("code", plan.Code)
                .AddUrlSegment("id", id)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }
    }
}
