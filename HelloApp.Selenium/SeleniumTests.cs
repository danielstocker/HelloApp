using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HelloApp.Selenium
{
    [TestClass]
    public class SeleniumTests
    {
        private static string WebAppUrl = "https://dandeployapp.azurewebsites.net";
        private static IWebDriver driver;

        [ClassInitialize]
        public static void SeleniumTestSetup(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        }

        [TestMethod]
        public void HelloAppTest()
        {
            driver.Navigate().GoToUrl(WebAppUrl);
            driver.FindElement(By.PartialLinkText("Hello.App")).Click();

            var element = driver.FindElement(By.CssSelector("p"));
            Assert.IsTrue(element.Text.Contains("Hello, please enter your name. Supply it as a GET parameter. (e.g. /Hello?name=Mickey Mouse&)"));

            driver.Navigate().GoToUrl(driver.Url + "?name=Mickey Mouse&");

            element = driver.FindElement(By.CssSelector("p"));
            Assert.IsTrue(element.Text.Contains("Hello Mickey Mouse"));
        }

        [ClassCleanup]
        public static void SeleniumTestCleanUp()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
