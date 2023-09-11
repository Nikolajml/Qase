using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using UI.Pages;

namespace Tests.UI
{
    public class CaseCreateTest : BaseTest
    {
        Case Case;
        public ProjectTPStepsPage ProjectTPStepsPage;
        public CaseStep _caseStep;

        [OneTimeSetUp]
        public void OniTimeTtestSetUp()
        {
            _caseStep = new CaseStep(_logger, Driver, _apiClient);
            ProjectTPStepsPage = new ProjectTPStepsPage(Driver);
        }

        [Test]
        [Description("Successful UI test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateCaseTest()
        {
            Case = new CaseBuilder()
                .SetCaseTitle(Faker.Name.FullName())
                .Build();

            ProjectTPStepsPage.NavigateToCreateCase();            
            Assert.IsTrue(_caseStep.IsPageOpened(), "The CasePage wasn't opened");

            _caseStep.CreateCase(Case);
            Assert.That(ProjectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title), "Title created Case desn't much to expected Case Title");
        }

        [TearDown]
        public void EditTearDown()
        {
            _caseStep.DeleteTestCaseByName(Case.Title, "TP");
        }
    }
}
