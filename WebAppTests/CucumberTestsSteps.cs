using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace WebAppTests
{
    [Binding]
    public class CucumberTestsSteps
    {
        IWebDriver driver;
        IWebElement element;

        [Given(@"I am at the login page")]
        public void GivenIAmAtTheLoginPage()
        {
            driver = new ChromeDriver();
            driver.Url = "http://spartaportal.azurewebsites.net/";
        }
        
        [Given(@"I have correctly entered my credentials")]
        public void GivenIHaveCorrectlyEnteredMyCredentials()
        {
            driver.FindElement(By.Id("Input_Email")).SendKeys("ADmin@spartaglobal.com");

            driver.FindElement(By.Id("Input_Password")).SendKeys("Admin123");
        }
        
        [When(@"I press Login")]
        public void WhenIPressLogin()
        {
            Thread.Sleep(1500);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
        }
        
        [Then(@"the result should be the User/Index page")]
        public void ThenTheResultShouldBeTheUserIndexPage()
        {
            true.Equals(driver.Url == "http://spartaportal.azurewebsites.net/Users");
            driver.Quit();
        }
    }
}
