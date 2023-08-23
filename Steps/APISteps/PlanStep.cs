using API.ResponseAPIModels;
using API.Services;
using Core.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace Steps.APISteps
{
    public class PlanStep : PlanService
    {
        public PlanStep(ApiClient apiClient) : base(apiClient)
        {

        }

        public PlanApiModel CreateTestPlan(Plan plan)
        {
            var response = CreatePlan(plan);

            return response;
        }

        public PlanApiModel GetTestPlan(Plan plan)
        {
            var response = GetPlan(plan);

            _logger.Info("Case: " + response.ToString());

            return response;
        }

        public PlanApiModel UpdateTestPlan(Plan plan)
        {
            var response = UpdatePlan(plan);

            _logger.Info("Case: " + response.ToString());

            return response;
        }

        public PlanApiModel DeleteTestPlan(Plan plan)
        {
            var response = DeletePlan(plan);

            _logger.Info("Case: " + response.ToString());

            return response;
        }
    }
}
