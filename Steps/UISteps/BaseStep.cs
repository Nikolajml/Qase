using UI.Pages;
using OpenQA.Selenium;

namespace Steps.UISteps
{
    public class BaseStep
    {
        protected IWebDriver Driver;

        public LoginPage LoginPage => new LoginPage(Driver);
        public PlanTPPage PlanTPPage => new PlanTPPage(Driver);
        public DefectsTPPage DefectsTPPage => new DefectsTPPage(Driver);
        

        // сделать частью соответсвующего конструктора

        public BaseStep(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
