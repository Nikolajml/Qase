using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using UI.Pages;
using Core.Utilities.Configuration;
using Core.Core;
using OpenQA.Selenium;

namespace Tests.UI
{
    public class CaseCreateTest : CommonBaseTest
    {
        Case Case;
        public ProjectTPStepsPage ProjectTPStepsPage;
        public CaseStep _caseStep;               

        [OneTimeSetUp]
        public void OniTimeTtestSetUp()
        {
            _caseStep = new CaseStep(logger, Driver, _apiClient);
            ProjectTPStepsPage = new ProjectTPStepsPage(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            NavigationSteps.CheckThatPageIsOpen();
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
