using OpenQA.Selenium;
using Qase.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Steps
{
    public class BaseStep
    {
        protected IWebDriver Driver;

        public LoginPage LoginPage => new LoginPage(Driver);
        public PlanTPPage PlanTPPage => new PlanTPPage(Driver);
        public DefectsTPPage DefectsTPPage => new DefectsTPPage(Driver);
        

        public BaseStep(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
