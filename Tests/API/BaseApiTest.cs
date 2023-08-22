using NUnit.Allure.Core;
using API.Services;
using Core.Client;
using Core.Utilities;

namespace Tests.API
{
    [AllureNUnit]
    public class BaseApiTest
    {
        protected ApiClient _apiClient;
        protected ProjectService _projectService;
        protected SuiteService _suiteService;
        protected CaseService _caseService;
        protected PlanService _planService;
        protected DefectService _defectService;
        protected EntityHandler entityHandler = new EntityHandler();

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient();
            _projectService = new ProjectService(_apiClient);
            _suiteService = new SuiteService(_apiClient);
            _caseService = new CaseService(_apiClient);
            _planService = new PlanService(_apiClient);
            _defectService = new DefectService(_apiClient);
        }
    }
}