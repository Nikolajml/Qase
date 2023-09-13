using Core.Client;
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
        public Case Case { get; set; }        

        protected CaseStep _caseStep;

        [OneTimeSetUp]
        public void Setup()
        {
            _caseStep = new CaseStep(logger, apiClient: _apiClient);

            Case = new Case()
            {
                Code = "PP",
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
                        
            Assert.IsFalse(createdTestCase.Status, "Status is not False");
            Assert.AreEqual("The title field is required.", createdTestCase.Message, "Error message doesn't match to expected error message");
        }
    }
}
