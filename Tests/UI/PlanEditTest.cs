using Bogus;
using Core.Client;
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
    public class PlanEditTest : CommonBaseTest
    {
        Plan plan;
        Case Case;

        public ProjectTPStepsPage ProjectTPStepsPage;
        public PlanStep _planStep;
        public CaseStep _caseStep;

        public List<Case> CasesForDelete = new List<Case>();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ProjectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            _caseStep = new CaseStep(logger, Driver, _apiClient);
            _planStep = new PlanStep(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            NavigationSteps.CheckThatPageIsOpen();
        }

        [SetUp]
        public void SetUp()
        {
            Case = new CaseBuilder()
                .SetCaseTitle(Faker.Name.FullName())
                .Build();

            ProjectTPStepsPage.NavigateToCreateCase();
            Assert.IsTrue(_caseStep.IsPageOpened(), "The CasePage wasn't opened");

            _caseStep.CreateCase(Case);
            Thread.Sleep(1000);
                        
            plan = new PlanBuilder()
                .SetPlanTitle(Faker.Name.FullName())
                .SetPlanDescription(Faker.Vehicle.Model())
                .Build();

            _planStep.NavigateToPlanPage();
            _planStep.CreatePlan(plan);
            Thread.Sleep(1000);
        }

        [Test]
        [Description("Successful UI test to create a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreatePlanTest()
        {
            
            plan = new PlanBuilder()
               .SetPlanTitle("Plan_Edit")
               .Build();

            _planStep.NavigateToPlanPage();
            _planStep.EditPlan(plan);

            Assert.That(_planStep.CreatedPlanTitleForFirstAssert(), Is.EqualTo(plan.Title));

            _planStep.NavigateToCreatedPlanForSecondAssert();

            Assert.That(_planStep.CreatedPlanTitleForSecondAssert(), Is.EqualTo(plan.Title));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _planStep.NavigateToPlanPage();
            _planStep.DeletePlan_UI();

            _caseStep.DeleteTestCaseByName(Case.Title, "TP");
        }

    }
}
