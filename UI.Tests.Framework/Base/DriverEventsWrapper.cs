using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using Tests.Tools.Logger;
using Tests.Tools.Logger.enums;
using Tests.Tools.Logger.interfaces;

/// <summary>
/// A WebDriver wrapper that enhances logging capabilities using EventFiringWebDriver
/// </summary>
public class DriverEventsWrapper
{
    private readonly EventFiringWebDriver driver;
    private readonly ILog logger;

    public DriverEventsWrapper()
    {
        driver = new EventFiringWebDriver(new ChromeDriver());
        logger = LoggerFactory.CreateLogger(LoggerType.UI);

        driver.Navigating += OnNavigating;
        driver.ElementClicked += OnElementClicked;
        driver.ExceptionThrown += OnExceptionThrown;
        driver.FindingElement += OnFindingElement;
    }

    private void OnNavigating(object sender, WebDriverNavigationEventArgs e)
    {
        logger.Log($"[WebDriver] Navigating to: {e.Url}");
    }

    private void OnElementClicked(object sender, WebElementEventArgs e)
    {
        logger.Log($"[WebDriver] Clicked element: {e.Element.TagName}");
    }

    private void OnExceptionThrown(object sender, WebDriverExceptionEventArgs e)
    {
        logger.Log($"[WebDriver] Exception: {e.ThrownException.Message}");
    }

    private void OnFindingElement(object sender, FindElementEventArgs e)
    {
        logger.Log($"[WebDriver] Finding element: {e.FindMethod}");
    }

    public IWebDriver GetDriver() => driver;
}