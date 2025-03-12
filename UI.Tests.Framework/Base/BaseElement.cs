using OpenQA.Selenium;
using UI.Tests.Framework.WebElements.Interfaces;

namespace UI.Tests.Framework.Base
{
    namespace UI.Tests.Framework.Base
    {
        /// <summary>
        /// Base behavior for all elements
        /// </summary>
        public abstract class BaseElement : IElement
        {
            public string XPath { get; set; }
            public IWebDriver Driver { get; set; }

            public BaseElement(string xpath, IWebDriver driver)
            {
                this.XPath = xpath;
                this.Driver = driver;
            }

            public string GetText()
            {
                return Driver.FindElement(By.XPath(XPath)).Text;
            }

            public string GetCssValue(string valueName)
            {
                return Driver.FindElement(By.XPath(XPath)).GetCssValue(valueName);
            }
        }
    }
}