using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;

namespace Tests.UI
{
    public class CaseCreateTest : BaseTest
    {
        Case Case;     

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
            CaseStep.CheckThatPageIsOpen();
            CaseStep.CreateCase(Case);

            Assert.That(ProjectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title), "sddsfdf");
        }                

        [TearDown]
        public void EditTearDown()
        {
            _caseStep.DeleteTestCaseByName(Case.Title, "TP");
        }
    }
}
