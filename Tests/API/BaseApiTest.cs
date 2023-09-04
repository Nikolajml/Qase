using NUnit.Allure.Core;
using Core.Client;
using Core.Utilities;
using Steps.Steps;
using NLog;

namespace Tests.API
{
    [AllureNUnit]
    public class BaseApiTest
    {
        protected Logger _logger = LogManager.GetCurrentClassLogger(); // Сделать логер частью конструктора

        protected CaseStep _caseStep;           // разбросать по соответсвующим классам
        protected DefectStep _defectStep;
        protected PlanStep _planStep;
        protected SuiteStep _suiteStep;
        protected ProjectStep _projectStep;

        ApiClient _apiClient;

        [OneTimeSetUp]                              // разбросать по соответсвующим классам
        public void InitApiClient()
        {
            _apiClient = new ApiClient();            

            _caseStep = new CaseStep(_apiClient);
            _defectStep = new DefectStep(_apiClient);
            _planStep = new PlanStep(_apiClient);
            _suiteStep = new SuiteStep(_apiClient);
            _projectStep = new ProjectStep(_apiClient);
        }
    }
}