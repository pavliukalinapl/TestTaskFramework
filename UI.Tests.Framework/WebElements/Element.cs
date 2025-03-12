using OpenQA.Selenium;
using UI.Tests.Framework.Base.UI.Tests.Framework.Base;

namespace UI.Tests.Framework.WebElements
{
    /// <summary>
    /// General ement like div to define not a typical general element
    /// </summary>
    public class Element : BaseElement
    {
        public Element(string xpath, IWebDriver driver) : base(xpath, driver)
        {
        }
    }
}