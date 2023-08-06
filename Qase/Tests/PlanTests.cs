using OpenQA.Selenium;
using Qase.Models;
using Qase.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests
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

            Assert.True(Driver.FindElement(By.XPath("//a[text()='New Plan']")).Displayed);
        }
    }
}
