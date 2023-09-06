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
        protected Logger _logger; // Сделать логер частью конструктора
        protected ApiClient _apiClient;

        // разбросать по соответсвующим классам
        //protected DefectStep _defectStep;
        //protected PlanStep _planStep;
        //protected SuiteStep _suiteStep;
        //protected ProjectStep _projectStep;



        [OneTimeSetUp]                              // разбросать по соответсвующим классам
        public void InitApiClient()
        {
            _apiClient = new ApiClient(new Configurator().Bearer);
            _logger = LogManager.GetCurrentClassLogger();

            //_defectStep = new DefectStep(_apiClient);
            //_planStep = new PlanStep(_apiClient);
            //_suiteStep = new SuiteStep(_apiClient);
            //_projectStep = new ProjectStep(_apiClient);
        }
    }
}