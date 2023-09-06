using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace Tests.UI
{
    public class CaseEditTest : BaseTest
    {
        Case Case;
        Case CaseForEdit;
        public CaseStep _caseStep;
        public ProjectTPStepsPage _projectTPStepsPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _caseStep = new CaseStep(Driver, _apiClient);
            _projectTPStepsPage = new ProjectTPStepsPage(Driver);
        }

        [SetUp]
        public void Setup()
        {
            Case = new Case()
            {
                Code = "TP",
                Title = "Case For EditCaseTest UI"
            };

            _caseStep.CreateTestCase(Case);
        }

        [Test]
        [Description("Successful UI test to edit a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditCaseTest()
        {
            CaseForEdit = new CaseBuilder()
               .SetCaseTitle("Edited Case UI")
               .Build();

            _projectTPStepsPage.NavigateToEditCase();
            _caseStep.EditCase(CaseForEdit);

            Assert.That(_projectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(CaseForEdit.Title));
        }

        [TearDown]
        public void EditTearDown()
        {
            _caseStep.DeleteTestCaseByName(Case.Title, Case.Code);
            _caseStep.DeleteTestCaseByName(CaseForEdit.Title, "TP");
        }
    }
}
