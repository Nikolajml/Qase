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
    public class CaseTests : BaseTest
    {
        [Test]
        public void CreateCaseTest()
        {
            Case Case = new CaseBuilder()
                .SetCaseTitle("New Case Test")
                .Build();

            var ProjectTPPage = new ProjectTPPage(Driver);

            ProjectTPPage.OpenPage();
            Thread.Sleep(2000);
            ProjectTPPage.CreateCase(Case);
            Thread.Sleep(2000);
            
            Assert.That(ProjectTPPage.GetCaseTitle(), Is.EqualTo("New Case Test"));
        }

        [Test]
        public void EditCaseTest()
        {
            Case Case = new CaseBuilder()
                .SetCaseTitle("Edited Case Test")
                .Build();

            var ProjectTPPage = new ProjectTPPage(Driver);

            ProjectTPPage.OpenPage();
            Thread.Sleep(2000);
            ProjectTPPage.EditCase(Case);
            Thread.Sleep(2000);

            Assert.That(ProjectTPPage.GetCaseTitle(), Is.EqualTo("Edited Case Test"));
        }
    }
}
