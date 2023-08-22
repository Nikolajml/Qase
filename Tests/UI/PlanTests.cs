using UI.Models;
using NUnit.Allure.Attributes;
using NUnit.Framework.Internal;

namespace Tests.UI
{
    public class PlanTests : BaseTest
    {

        [Test, Order(1)]
        [Description("Successful UI test to create a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreatePlanTest()
        {
            Plan plan = new PlanBuilder()
                .SetPlanTitle("New Plan 333")
                .SetPlanDescription("Description for New Plan")
                .Build();                                                   // Что, если я буду делать клин-уп

            PlanTPPage.OpenPage();            
            PlanStepsPage.CreatePlan(plan);

            entityHandler.PlansForDelete.Add(plan);

            Assert.That(PlanTPPage.GetPlanTitle(), Is.EqualTo(plan.Title));

            PlanTPPage.ClickToCreatedPlanTitleToAssert();

            Assert.Multiple(() =>                                           // Ассерт через объект
            {
                Assert.That(PlanTPPage.GetPlanTitleForSecondAssert(), Is.EqualTo(plan.Title));
                Assert.That(PlanTPPage.GetPlanDescriptionForSecondAssert(), Is.EqualTo(plan.Description));
            });
        }

        [Test, Order(2)]
        [Description("Successful UI test to edit a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditPlanTest()
        {
            Plan plan = new PlanBuilder()
                .SetPlanTitle("Plan_Edit")
                .Build();

            PlanTPPage.OpenPage();
            PlanTPPage.IsPageOpened();
            PlanStepsPage.EditPlan(plan);

            Assert.That(PlanTPPage.GetPlanTitle(), Is.EqualTo(plan.Title));
        }
    }
}
