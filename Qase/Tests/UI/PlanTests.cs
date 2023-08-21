using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Models;
using Qase.Pages;
using Qase.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests.UI
{
    public class PlanTests : BaseTest
    {

        [Test, Order(1)]
        [Description("Successful UI test to create a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void CreatePlanTest()
        {
            Plan plan = new PlanBuilder()
                .SetPlanTitle("New Plan 333")
                .SetPlanDescription("Description for New Plan")
                .Build();                                                   // Что, если я буду делать клин-уп
                        
            PlanTPPage.OpenPage();
            PlanTPPage.IsPageOpened();                                      //I use IsPageOpened method
            PlanStepsPage.CreatePlan(plan);
            PlanTPPage.WaitPlan();

            Assert.That(PlanTPPage.GetPlanTitle(), Is.EqualTo(plan.Title));                               
                        
            PlanTPPage.ClickToCreatedPlanTitleToAssert();
            PlanTPPage.WaitOpenPlanDetails();            

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
        public void EditPlanTest()
        {
            Plan plan = new PlanBuilder()
                .SetPlanTitle("Plan_Edit")
                .Build();

            PlanTPPage.OpenPage();
            PlanTPPage.IsPageOpened();
            PlanStepsPage.EditPlan(plan);
            PlanTPPage.WaitPlan();

            Assert.That(PlanTPPage.GetPlanTitle(), Is.EqualTo(plan.Title));
        }
    }
}
