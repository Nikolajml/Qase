using NUnit.Allure.Core;
using Qase.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qase.Services;

namespace Qase.Tests.API
{
    [AllureNUnit]
    public class BaseApiTest
    {
        protected ApiClient _apiClient;
        protected ProjectService _projectService;
        protected SuiteService _suiteService;        

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient();
            _projectService = new ProjectService(_apiClient);
            _suiteService = new SuiteService(_apiClient);            
        }
    }
}
