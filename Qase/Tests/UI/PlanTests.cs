using OpenQA.Selenium;
using Qase.Models;
using Qase.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests.UI
{
    public class PlanTests : BaseTest
    {
        [Test]
        public void CreatePlanTest()
        {
            Plan plan = new PlanBuilder()
                .SetPlanTitle("New Plan")
                .SetPlanDescription("Description for New Plan")
                .Build();

            var PlanTPPage = new PlanTPPage(Driver);

            PlanTPPage.OpenPage();
            Thread.Sleep(2000);
            PlanTPPage.CreatePlan(plan);
            Thread.Sleep(2000);

            Assert.That(PlanTPPage.GetPlanTitle(), Is.EqualTo("New Plan"));
        }

        [Test]
        public void EditPlanTest()
        {
            Plan plan = new PlanBuilder()
                .SetPlanTitle("Plan_Edit")
                .Build();

            var PlanTPPage = new PlanTPPage(Driver);

            PlanTPPage.OpenPage();
            Thread.Sleep(2000);
            PlanTPPage.EditPlan(plan);
            Thread.Sleep(2000);

            Assert.That(PlanTPPage.GetPlanTitle(), Is.EqualTo("Plan_Edit"));
        }
    }
}
