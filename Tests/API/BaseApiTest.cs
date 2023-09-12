using NUnit.Allure.Core;
using Core.Client;
using Core.Utilities;
using Steps.Steps;
using NLog;
using Core.Utilities.Configuration;

namespace Tests.API
{
    [AllureNUnit]
    public class BaseApiTest
    {
        protected ILogger logger;
        protected ApiClient _apiClient;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient(new Configurator().Bearer);
            logger = LogManager.GetCurrentClassLogger();
        }
    }
}