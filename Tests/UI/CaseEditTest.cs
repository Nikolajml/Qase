using Core.Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace Tests.UI
{
    public class CaseEditTest : CommonBaseTest
    {
        Case Case;
        Case CaseForEdit;
        public CaseStep _caseStep;
        public ProjectTPStepsPage _projectTPStepsPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {            
            _caseStep = new CaseStep(logger, Driver, _apiClient);
            _projectTPStepsPage = new ProjectTPStepsPage(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            NavigationSteps.IsPageOpened();
        }

        [SetUp]
        public void Setup()
        {
            Case = new Case()
            {
                Code = "TP",
                Title = Faker.Name.FullName()
            };

            _caseStep.CreateTestCase_API(Case);
        }

        [Test]
        [Description("Successful UI test to edit a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditCaseTest()
        {
            CaseForEdit = new CaseBuilder()
               .SetCaseTitle(Faker.Name.FullName())
               .Build();

            _projectTPStepsPage.NavigateToEditCase();
            _caseStep.EditCase(CaseForEdit);

            Assert.That(_projectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(CaseForEdit.Title), "Edited Case Title doesn't mutch to expected Case Title");
        }

        [TearDown]
        public void EditTearDown()
        {
            _caseStep.DeleteTestCaseByName(Case.Title, Case.Code);
            _caseStep.DeleteTestCaseByName(CaseForEdit.Title, "TP");
        }
    }
}
