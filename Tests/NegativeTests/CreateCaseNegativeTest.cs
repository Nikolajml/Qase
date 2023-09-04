using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tests.API;
using UI.Models;

namespace Tests.NegativeTests
{
    internal class CreateCaseNegativeTest : BaseApiTest
    {
        public List<Case> CasesForDelete = new();
        public Case Case { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            Case = new Case()
            {
                Code = "OE",
                Title = ""
            };
        }


        [Test]
        [Description("Successful API test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreateInvalidCaseTest()
        {
            var createdTestCase = _caseStep.CreateTestCaseWithIncorrectAuthenticated(Case);
            //Case.Id = createdTestCase.Result.id.ToString();             // как будет работать, если тест упадет
            CasesForDelete.Add(Case);

            Assert.Multiple(() =>
            {
                Assert.IsFalse(createdTestCase., "Status code: True - Case was created");
                //Assert.AreEqual(Case.Id, createdTestCase.Result.id.ToString(), "Case ID don't match");
                //Assert.AreEqual(createdTestCase.Result.status, "");
                //Assert.AreEqual(HttpStatusCode, createdTestCase.Result.StatusCode);


            });
        }
    }
}
