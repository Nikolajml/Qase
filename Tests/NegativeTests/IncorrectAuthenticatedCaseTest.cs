using Core.Client;
using Core.Utilities.Configuration;
using NLog;
using NUnit.Allure.Attributes;
using Steps.Steps;
using System.Net;
using Tests.API;
using UI.Models;

namespace Tests.NegativeTests
{
    public class IncorrectAuthenticatedCaseTest : CommonBaseTest
    {
        public ILogger logger;
        public Case Case { get; set; }                
        
        protected CaseStep _caseStep;

        protected ApiClient _apiClient;

        [OneTimeSetUp]
        public void Setup()
        {
            _apiClient = new ApiClient();
            logger = LogManager.GetCurrentClassLogger();

            _caseStep = new CaseStep(logger, apiClient: _apiClient);

            Case = new Case()
            {
                Code = "TP", 
                Title = "Incorrect Authenticated Case"
            };
        }

        [Test]
        [Description("API test with Incorrect Authenticated to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        [Category("Negative")]
        public void IncorrectAuthenticatedCreateCaseTest()
        {
            var createdTestCase = _caseStep.CreateTestCase_API(Case);

            Assert.IsFalse(createdTestCase.Status, "Status is not False");
            Assert.AreEqual("Unauthenticated.", createdTestCase.Error, "Error doesn't match to expected error");
        }
    }
}
