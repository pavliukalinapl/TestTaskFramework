using Tests.Data.Constants;
using UI.Tests.Base;
using UI.Tests.Pages;

namespace UI.Tests.Tests
{
    public class Tests : BaseTest
    {
        [Test]
        [TestCase("Fried Chicken")]
        [TestCase("Ice Cream")]
        [TestCase("Hamburger")]
        public void Test_DragAndDrop(string menuItem)
        {
            new DragAndDropPage(driver)
                .Open()
                .AddMenuItemToOrderTicket(menuItem)
                .AssertOrderText(menuItem)
                .AssertOrderBorderColor(Colors.Green);
        }
    }
}