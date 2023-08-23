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
    public class SuiteStep : SuiteService
    {
        public SuiteStep(ApiClient apiClient) : base(apiClient)
        {
        }

        public SuiteApiModel CreateTestDefect(Suite suite)
        {
            var response = CreateSuite(suite);

            return response;

        }

        public SuiteApiModel GetTestDefect(Suite suite)
        {
            var response = GetSuite(suite);

            _logger.Info("Case: " + response.ToString());

            return response;
        }

        public SuiteApiModel UpdateTestDefect(Suite suite)
        {
            var response = UpdateSuite(suite);

            _logger.Info("Case: " + response.ToString());

            return response;

        }

        public SuiteApiModel DeleteTestDefect(Suite suite)
        {
            var response = DeleteSuite(suite);

            _logger.Info("Case: " + response.ToString());

            return response;
        }
    }
}
