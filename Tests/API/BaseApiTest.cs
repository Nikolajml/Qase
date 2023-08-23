using NUnit.Allure.Core;
using API.Services;
using Core.Client;
using Core.Utilities;
using Steps.APISteps;
using NLog;

namespace Tests.API
{
    [AllureNUnit]
    public class BaseApiTest
    {
        protected Logger _logger = LogManager.GetCurrentClassLogger();

        protected ApiClient _apiClient;
        protected ProjectService _projectService;
        protected SuiteService _suiteService;
        protected CaseService _caseService;
        protected PlanService _planService;
        protected DefectService _defectService;

        protected CaseStep _caseStep;
        protected DefectStep _defectStep;
        protected PlanStep _planStep;
        protected SuiteStep _suiteStep;

        protected CleanUpHandler cleanUpHandler = new CleanUpHandler();

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient();
            _projectService = new ProjectService(_apiClient);
            _suiteService = new SuiteService(_apiClient);
            _caseService = new CaseService(_apiClient);
            _planService = new PlanService(_apiClient);
            _defectService = new DefectService(_apiClient);

            _caseStep = new CaseStep(_apiClient);
            _defectStep = new DefectStep(_apiClient);
            _planStep = new PlanStep(_apiClient);
            _suiteStep = new SuiteStep(_apiClient);
        }
    }
}