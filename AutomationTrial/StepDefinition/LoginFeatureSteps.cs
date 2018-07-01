using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow;
using NUnit.Framework;
using log4net;

namespace AutomationTrial
{
    [Binding]
    public class LoginFeatureSteps
    {
        private static readonly ILog Log =
              LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IWebDriver driver = new ChromeDriver();
        

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            Log.Info("Launching the browser.........");
            driver.Navigate().GoToUrl("https://www.nopcommerce.com/login.aspx");
            driver.Manage().Window.Maximize();
        }
        
        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
                      
            Log.Info("Entering the username and password");
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_UserName']")).SendKeys((string)data.UserName);
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_Password']")).SendKeys((string)data.Password);

        }
        
        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            Log.Info("Clicking on login button");
            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();
        }
        
        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            Log.Info("User logged in and checking for <Logout> button");
            var logout = driver.FindElements(By.XPath("//a[@class='ico-logout']"))[0];
            Assert.IsTrue(logout.Displayed);

        }
        //tear down
        [AfterScenario]
        public void CleanUp()
        {
            Log.Info("Quiting the browser");
            driver.Quit();
        }

    }
}
