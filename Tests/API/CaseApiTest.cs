using UI.Models;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Framework.Internal;

namespace Tests.API
{
    public class CaseApiTest : BaseApiTest
    {
        public Case Case { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            Case = new Case()
            {
                Code = "OE",
                Title = "Case_api_New"
            };
        }

        [Test, Order(1)]
        [Description("Successful API test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreateCaseTest()
        {
            var createdTestCase = _caseStep.CreateTestCase(Case);

            Case.Id = createdTestCase.Result.id.ToString();

            cleanUpHandler.CasesForDelete.Add(Case);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdTestCase.Status);
                Assert.AreEqual(Case.Id, createdTestCase.Result.id.ToString());
            });
        }

        [Test, Order(2)]
        [Description("Successful API test to get a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]

        public void GetCaseTest()
        {
            var testCase = _caseStep.GetTestCase(Case);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(testCase.Status);
                Assert.AreEqual(Case.Id, testCase.Result.id.ToString());
            });
        }

        [Test, Order(3)]
        [Description("Successful API test to update a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void UpdateCaseTest()
        {
            Case.Title = "New Update API";
            Case.Description = "New Description API";

            var caseResponse = _caseStep.UpdateTestCase(Case);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(caseResponse.Status);
                Assert.AreEqual(Case.Id, caseResponse.Result.id.ToString());                
            });
        }

        [Test, Order(4)]
        [Description("Successful test to delete a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeleteCaseTest()
        {
            var caseResponse = _caseStep.DeleteTestCase(Case);
            
            Assert.Multiple(() =>
            {
                Assert.IsTrue(caseResponse.Status);
                Assert.AreEqual(Case.Id, caseResponse.Result.id.ToString());
            });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            cleanUpHandler.DeleteCases();
        }
    }
}