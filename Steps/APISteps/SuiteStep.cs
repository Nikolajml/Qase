using API.ResponseAPIModels;
using API.Services;
using Core.Client;
using UI.Models;

namespace Steps.APISteps
{
    public class SuiteStep : SuiteService
    {
        public SuiteStep(ApiClient apiClient) : base(apiClient)
        {
        }

        public SuiteApiModel CreateTestSuite(Suite suite)
        {
            var response = CreateSuite(suite);

            return response;

        }

        public SuiteApiModel GetTestSuite(Suite suite)
        {
            var response = GetSuite(suite);

            _logger.Info("Case: " + response.ToString());

            return response;
        }

        public SuiteApiModel UpdateTestSuite(Suite suite)
        {
            var response = UpdateSuite(suite);

            _logger.Info("Case: " + response.ToString());

            return response;

        }

        public SuiteApiModel DeleteTestSuite(Suite suite)
        {
            var response = DeleteSuite(suite);

            _logger.Info("Case: " + response.ToString());

            return response;
        }
    }
}
