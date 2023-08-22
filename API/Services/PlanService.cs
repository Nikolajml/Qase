using UI.Models;
using API.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using RestSharp;

namespace API.Services
{
    public class PlanService : BaseService
    {
        public PlanService(ApiClient apiClient) : base(apiClient)
        {

        }

        public PlanApiModel GetPlan(Plan plan)
        {
            var request = new RestRequest(Endpoints.GET_PLAN)
                .AddUrlSegment("code", plan.Code)
                .AddUrlSegment("id", plan.Id)                
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }

        public PlanApiModel CreatePlan(Plan plan)
        {
            var request = new RestRequest(Endpoints.CREATE_PLAN, Method.Post)
                .AddUrlSegment("code", plan.Code)                
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }

        public PlanApiModel UpdatePlan(Plan plan)
        {
            var request = new RestRequest(Endpoints.UPDATE_PLAN, Method.Patch)
                .AddUrlSegment("code", plan.Code)
                .AddUrlSegment("id", plan.Id)                
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }

        public PlanApiModel DeletePlan(Plan plan)
        {
            var request = new RestRequest(Endpoints.DELETE_PLAN, Method.Delete)
                .AddUrlSegment("code", plan.Code)
                .AddUrlSegment("id", plan.Id)                
                .AddBody(plan);

            return _apiClient.Execute<PlanApiModel>(request);
        }
    }
}
