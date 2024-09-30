using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumNUnitExample
{
    [TestFixture]
    public class GoogleSearchTest1
    {
        private IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            // Initialize the ChromeDriver
            driver = new ChromeDriver(@"C:\Users\opilane\source\repos\SeleniumCsharp\SeleniumCsharp\drivers");
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            // Set an implicit wait time
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void SearchTest()
        {
            // Navigate to the URL
            driver!.Navigate().GoToUrl("https://lucagluhhov22.thkit.ee/Content/toolivara/table3.php");

            // Accept cookies if prompted (optional, depends on region)
            try
            {
                var acceptCookiesButton = driver.FindElement(By.Id("echo1"));
                acceptCookiesButton.Click();
            }
            catch (NoSuchElementException)
            {
                // Do nothing if the accept cookies button is not present
            }
        }

        // 1. Title Verification Test
        [Test]
        public void VerifyPageTitleTest()
        {
            driver!.Navigate().GoToUrl("https://lucagluhhov22.thkit.ee/Content/toolivara/table3.php");
            string pageTitle = driver.Title;
            Assert.AreEqual("Toolid", pageTitle, "The page title does not match.");
        }

        // 2. Element Interaction Test
        [Test]
        public void ElementInteractionTest()
        {
            driver!.Navigate().GoToUrl("https://lucagluhhov22.thkit.ee/Content/toolivara/table1.php");

            // Find an input field and enter some text
            IWebElement inputField = driver.FindElement(By.Id("yourInputFieldId"));
            inputField.SendKeys("Test input");

            // Submit a form or click a button
            IWebElement submitButton = driver.FindElement(By.Id("pluspunkt"));
            submitButton.Click();

            // Assert the success or next step after the form submission
            Assert.IsTrue(driver.Url.Contains("https://lucagluhhov22.thkit.ee/Content/toolivara/table1.php?pluspunkt=28"), "The form submission did not navigate as expected.");
        }

        // 3. Page Navigation Test
        [Test]
        public void VerifyUrlTest()
        {
            driver!.Navigate().GoToUrl("https://lucagluhhov22.thkit.ee/Content/toolivara/table3.php");
            string currentUrl = driver.Url;
            Assert.AreEqual("https://lucagluhhov22.thkit.ee/Content/toolivara/table3.php", currentUrl, "The URL is incorrect.");
        }

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();     // Close all browser windows and safely end the session
                driver.Dispose();  // Release all resources
                driver = null;     // Set driver to null to aid garbage collection
            }
        }
    }
}