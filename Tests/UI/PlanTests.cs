using UI.Models;
using NUnit.Allure.Attributes;
using NUnit.Framework.Internal;
using Steps.Steps;

namespace Tests.UI
{
    public class PlanTests : BaseTest
    {
        Plan plan;

        public PlanStep _planStep;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _planStep = new PlanStep(Driver);            
        }


        [Test]
        [Description("Successful UI test to create a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreatePlanTest()
        {
            Plan plan = new PlanBuilder()
                .SetPlanTitle("New Plan 333")
                .SetPlanDescription("Description for New Plan")
                .Build();

            _planStep.NavigateToPlanPage();
            _planStep.CreatePlan(plan);

            //cleanUpHandler.PlansForDelete.Add(plan);

            Assert.That(_planStep.CreatedPlanTitleForFirstAssert(), Is.EqualTo(plan.Title));

            _planStep.NavigateToCreatedPlanForSecondAssert();

            Assert.Multiple(() =>                                           
            {
                Assert.That(_planStep.CreatedPlanTitleForSecondAssert(), Is.EqualTo(plan.Title));
                Assert.That(_planStep.CreatedPlanDescriptionForSecondAssert, Is.EqualTo(plan.Description));
            });
        }

        [Test]
        [Description("Successful UI test to edit a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditPlanTest()
        {
            Plan plan = new PlanBuilder()
                .SetPlanTitle("Plan_Edit")
                .Build();

            //PlanTPPage.OpenPage();
            //PlanTPPage.IsPageOpened();
            _planStep.NavigateToPlanPage();
            _planStep.EditPlan(plan);

            Assert.That(_planStep.CreatedPlanTitleForFirstAssert(), Is.EqualTo(plan.Title));

            _planStep.NavigateToCreatedPlanForSecondAssert();

            Assert.That(_planStep.CreatedPlanTitleForSecondAssert(), Is.EqualTo(plan.Title));
        }
    }
}
