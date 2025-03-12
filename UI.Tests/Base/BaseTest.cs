using OpenQA.Selenium;

namespace UI.Tests.Base
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var loggingDriver = new DriverEventsWrapper();
            driver = loggingDriver.GetDriver();
            // TODO: Implement more complex solution for managing WebDriver and to support additional browser configurations.

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // TODO: Implement more complex waiting mechanism using explicit wait strategies.
        }

        [TearDown]
        public void Cleanup()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}