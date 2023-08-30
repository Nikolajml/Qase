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
        protected Logger _logger = LogManager.GetCurrentClassLogger(); // Сделать логер частью конструктора

        protected CaseStep _caseStep;
        protected DefectStep _defectStep;
        protected PlanStep _planStep;
        protected SuiteStep _suiteStep;

        ApiClient _apiClient;
        protected CleanUpHandler cleanUpHandler = new CleanUpHandler();

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient();            

            _caseStep = new CaseStep(_apiClient);
            _defectStep = new DefectStep(_apiClient);
            _planStep = new PlanStep(_apiClient);
            _suiteStep = new SuiteStep(_apiClient);
        }
    }
}