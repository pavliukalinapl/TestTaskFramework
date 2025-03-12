using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UI.Tests.Framework.Base.UI.Tests.Framework.Base;
using UI.Tests.Framework.WebElements.Interfaces;

namespace UI.Tests.Framework.WebElements
{
    /// <summary>
    /// Provides interaction methods for handling label elements in a web application.
    /// </summary>
    public class Label : BaseElement, ILabel
    {
        public Label(string xpath, IWebDriver driver) : base(xpath, driver)
        {
        }

        public void DragAndDrop(IElement elementTo)
        {
            var actions = new Actions(Driver);
            actions.DragAndDrop(
                Driver.FindElement(By.XPath(XPath)),
                Driver.FindElement(By.XPath(((BaseElement)elementTo).XPath)))
            .Perform();
        }
    }
}