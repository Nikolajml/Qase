using Core.Client;
using Core.Utilities.Configuration;
using NUnit.Allure.Attributes;
using Steps.Steps;
using System.Net;
using Tests.API;
using UI.Models;

namespace Tests.NegativeTests
{
    internal class IncorrectAuthenticatedCaseTest : BaseApiTest
    {
        public List<Case> CasesForDelete = new();
        public Case Case { get; set; }
        protected CaseStep _caseStep;

        [OneTimeSetUp]
        public void Setup()
        {
            _apiClient = new ApiClient();
            _caseStep = new CaseStep(apiClient: _apiClient);

            Case = new Case()
            {
                Code = "PP", 
                Title = "Incorrect Authenticated Case"
            };
        }

        [Test]
        [Description("Successful API test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        [Category("Negative")]
        public void IncorrectAuthenticatedCreateCaseTest()
        {
            var createdTestCase = _caseStep.CreateTestCaseWithIncorrectAuthenticated(Case);

            CasesForDelete.Add(Case);

            Assert.IsNotEmpty(createdTestCase.Error, "Error is empty");
            Assert.AreEqual(createdTestCase.Error, "Unauthenticated.", "Eror is empty");
        }
    }
}
