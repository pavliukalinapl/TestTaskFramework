using Configuration.Config;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using Tests.Tools.Logger;
using Tests.Tools.Logger.enums;
using Tests.Tools.Logger.interfaces;

namespace UI.Tests.Framework.Base
{
    /// <summary>
    /// Base behavior for all pages
    /// </summary>
    public class BasePage
    {
        protected readonly string BaseUrl;
        public IWebDriver Driver { get; set; }
        protected IConfiguration config;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;

            config = new Configurator().GetConfig();
            BaseUrl = config.GetSection($"{ConfigKeys.GlobalParameters}")[ConfigKeys.UiBaseUrl];
        }
    }
}