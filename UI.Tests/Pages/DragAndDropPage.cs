using OpenQA.Selenium;
using UI.Tests.Framework.Base;
using UI.Tests.Framework.WebElements;
using UI.Tests.Framework.WebElements.Interfaces;

namespace UI.Tests.Pages
{
    public class DragAndDropPage : BasePage
    {
        private IElement OrderTicket => new Element("//*[@id='plate-items']", Driver);

        private ILabel MenuItem(string menuItemName) => new Label($"//li[text()='{menuItemName}']", Driver);

        public DragAndDropPage(IWebDriver driver) : base(driver)
        {
        }

        public DragAndDropPage Open()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/ingredients/drag-and-drop");
            return this;
        }

        public DragAndDropPage AddMenuItemToOrderTicket(string menuItemName)
        {
            MenuItem(menuItemName).DragAndDrop(OrderTicket);

            return this;
        }

        public DragAndDropPage AssertOrderText(string expectedOrderText)
        {
            var actualOrderTicketText = OrderTicket.GetText();

            Assert.That(actualOrderTicketText, Is.EqualTo(expectedOrderText), "Incorrect order ticket text");

            return this;
        }

        internal DragAndDropPage AssertOrderBorderColor(string expectedColor)
        {
            var actualColor = OrderTicket.GetCssValue("border");

            Assert.That(actualColor, Contains.Substring(expectedColor), "Incorrect order ticket color");

            return this;
        }
    }
}