using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;

namespace Selenium_Tests
{
    public class TestingUserPortal
    {
        IWebDriver driver;
        IWebElement element;

        [SetUp]

        public void Initialise()
        {
            driver = new ChromeDriver();

        }
        [Test]
        public void Selenium_Test_BBC_site()
        {
            driver.Url = "http://spartaportal.azurewebsites.net/login";
            //  Console.WriteLine(driver.PageSource); //shows bbc's html code
            Console.WriteLine($"Page Length is {driver.PageSource.Length}");
            Console.WriteLine($"Page URL is {driver.Url}");
            Console.WriteLine($"Page Title is {driver.Title}");

            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://spartaportal.azurewebsites.net/Users");
            Thread.Sleep(1500);
            driver.Navigate().Back();
            Thread.Sleep(1500);
            driver.Navigate().Forward();
            Thread.Sleep(1500);
            driver.Navigate().Refresh(); // refreshes the page it's currently on. 
            Thread.Sleep(1500);

        }

        [Test]
        public void Selenium_Test_Student_portal()
        {
            driver.Url = "http://spartaportal.azurewebsites.net/login";

            //select an individual web element on the page
            element = driver.FindElement(By.Name("email"));
            //add text to Email Textbox
            element.SendKeys("jrai@spartaglobal.com");
            Thread.Sleep(1500);

            //add text to Email Textbox
            element = driver.FindElement(By.Name("password"));
            element.SendKeys("Password1");

            //find the submit button
            //click to log in

            element = driver.FindElement(By.CssSelector(".btn-primary"));
            //OR       element = driver.FindElement(By.ClassName("btn-primary"));
            element.Click();

            //   < input class="btn btn-primary btn-md btn-block" type="submit" value="Submit">


            //element to look at users without log in
            element = driver.FindElement(By.LinkText("Users")); // Users is unique on the page so can find like this
            element.Click(); // gives error as we are not logged in. this is what we want to acheive in our test. 
            Thread.Sleep(4000);

        }


        [TearDown]
        public void Cleanup()
        {
            Thread.Sleep(3000);
            driver.Close();
            driver.Quit();
        }
    }
}
