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
        protected Logger _logger;
        protected ApiClient _apiClient;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient(new Configurator().Bearer);
            _logger = LogManager.GetCurrentClassLogger();
        }


        //TearDown use here
    }
}