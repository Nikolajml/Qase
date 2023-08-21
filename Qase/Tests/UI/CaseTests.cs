using NUnit.Allure.Attributes;
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
    public class CaseTests : BaseTest
    {
        [Test, Order(1)]
        [Description("Successful UI test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]        
        public void CreateCaseTest()
        {
            Case Case = new CaseBuilder()
                .SetCaseTitle("New Case Test UI")
                .Build();                      

            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            CaseStepsPage.CreateCase(Case);
            ProjectTPPage.WaitCaseTitle();

            Assert.That(ProjectTPPage.GetCreatedCaseTitle(), Is.EqualTo(Case.Title));
        }

        [Test, Order(2)]
        [Description("Successful UI test to edit a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void EditCaseTest()
        {
            Case Case = new CaseBuilder()
                .SetCaseTitle("Edited Case UI")
                .Build();                       

            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            CaseStepsPage.EditCase(Case);
            ProjectTPPage.WaitCaseTitle();

            Assert.That(ProjectTPPage.GetCreatedCaseTitle(), Is.EqualTo(Case.Title));
        }
    }
}
