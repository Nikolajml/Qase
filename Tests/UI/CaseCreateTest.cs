using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;

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
            _caseStep = new CaseStep(Driver, _apiClient);
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
                .SetCaseTitle("NIKOLAY")
                .Build();

            ProjectTPStepsPage.NavigateToCreateCase();
            _caseStep.CheckThatPageIsOpen();
            _caseStep.CreateCase(Case);

            Assert.That(ProjectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title), "sddsfdf");
        }

        [TearDown]
        public void EditTearDown()
        {
            _caseStep.DeleteTestCaseByName(Case.Title, "TP");
        }
    }
}
