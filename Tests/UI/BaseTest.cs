using Allure.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using UI.Pages;
using Core.Utilities.Configuration;
using Steps.Steps;
using Core.Core;
using Core.Utilities;
using Bogus;
using Tests.API;

namespace Tests.UI
{
    [AllureNUnit]
    public class BaseTest : BaseApiTest
    {
        public static readonly string? BaseUrl = new Configurator().AppSettings.URL;

        protected IWebDriver Driver;
        private AllureLifecycle _allure;       
        public Faker Faker = new Faker();

        
        //public PlanStepsPage PlanStepsPage; // РАЗНЕСТИ ПО СООТВЕТСУЮЩИМ КЛАССАМ
        //public DefectStepsPage DefectStepsPage;
        //public SuiteStepsPage SuiteStepsPage;
        //public CaseStepsPage CaseStepsPage;
        //public ProjectTPStepsPage ProjectTPStepsPage;
        public NavigationSteps NavigationSteps;
        
        public PlanStep PlanStep;
        //public DefectStep DefectStep;
        //public SuiteStep SuiteStep;
        //public CaseStep CaseStep;


        [OneTimeSetUp] 
        public void Setup()
        {
            Driver = new Browser().Driver;
            _allure = AllureLifecycle.Instance;
           
            NavigationSteps = new NavigationSteps(Driver);          // РАЗНЕСТИ ПО СООТВЕТСУЮЩИМ КЛАССАМ
                                                                    
            //PlanStepsPage = new PlanStepsPage(Driver);                        
            //DefectStepsPage = new DefectStepsPage(Driver);                        
            //SuiteStepsPage = new SuiteStepsPage(Driver);
            //CaseStepsPage = new CaseStepsPage(Driver);

            //PlanStep = new PlanStep(Driver);
            //DefectStep = new DefectStep(Driver);
            //SuiteStep = new SuiteStep(Driver);
            //CaseStep = new CaseStep(Driver);

            //ProjectTPStepsPage = new ProjectTPStepsPage(Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(new Configurator().Admin);
            NavigationSteps.CheckThatPageIsOpened();
        }

        [OneTimeTearDown] // Impliment OneTearDown
        public void TearDown()
        {
            // Проверка, что тест упал
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // Создание скриншота
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                // Прикрепление сриншота
                _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }

            Driver.Quit();
            Driver.Dispose();
        }
    }
}
