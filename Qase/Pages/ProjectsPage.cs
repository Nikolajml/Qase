﻿using OpenQA.Selenium;
using Qase.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Pages
{
    public class ProjectsPage : BasePage
    {
        private static string END_POINT = "projects";

        private static readonly By CreateNewProjectButtonBy = By.Id("createButton");

        public ProjectsPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }

        public ProjectsPage(IWebDriver? driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(CreateNewProjectButtonBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }



    }
}
