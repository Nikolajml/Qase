using Core.Client;
using Core.Utilities.Configuration;
using NLog;
using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.API;
using UI.Models;

namespace Tests.NegativeTests
{
    public class IncorrectRequiredDataCaseTest : CommonBaseTest
    {
        public ILogger logger;
        public Case Case { get; set; }        

        protected CaseStep _caseStep;

        protected ApiClient _apiClient;

        [OneTimeSetUp]
        public void Setup()
        {
            _apiClient = new ApiClient(new Configurator().Bearer);
            logger = LogManager.GetCurrentClassLogger();

            _caseStep = new CaseStep(logger, apiClient: _apiClient);

            Case = new Case()
            {
                Code = "TP",
                Title = ""
            };
        }

        [Test]
        [Description("Incorrect API test to create a Case without a title")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        [Category("Negative")]
        public void IncorrectRequiredDataCreateCaseTest()
        {
            var createdTestCase = _caseStep.CreateTestCase_API(Case);

            Assert.IsTrue(createdTestCase.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity, "Status is not False");
            Assert.AreEqual("The title field is required.", createdTestCase.Message, "Error message doesn't match to expected error message");
        }
    }
}
