using NUnit.Allure.Core;
using Qase.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qase.Services;
using System.Reflection.Metadata;

namespace Qase.Tests.API
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
