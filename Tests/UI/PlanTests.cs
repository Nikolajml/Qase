using UI.Models;
using NUnit.Allure.Attributes;
using NUnit.Framework.Internal;
using Steps.Steps;

namespace Tests.UI
{
    public class PlanTests : BaseTest
    {
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

            PlanStep.NavigateToPlanPage();
            PlanStep.CreatePlan(plan);

            //cleanUpHandler.PlansForDelete.Add(plan);

            Assert.That(PlanStep.CreatedPlanTitleForFirstAssert(), Is.EqualTo(plan.Title));

            PlanStep.NavigateToCreatedPlanForSecondAssert();

            Assert.Multiple(() =>                                           
            {
                Assert.That(PlanStep.CreatedPlanTitleForSecondAssert(), Is.EqualTo(plan.Title));
                Assert.That(PlanStep.CreatedPlanDescriptionForSecondAssert, Is.EqualTo(plan.Description));
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
            PlanStep.NavigateToPlanPage();
            PlanStep.EditPlan(plan);

            Assert.That(PlanStep.CreatedPlanTitleForFirstAssert(), Is.EqualTo(plan.Title));

            PlanStep.NavigateToCreatedPlanForSecondAssert();

            Assert.That(PlanStep.CreatedPlanTitleForSecondAssert(), Is.EqualTo(plan.Title));
        }
    }
}
