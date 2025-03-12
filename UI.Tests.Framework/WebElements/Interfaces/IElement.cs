namespace UI.Tests.Framework.WebElements.Interfaces
{
    public interface IElement
    {
        public string GetText();

        public string GetCssValue(string valueName);
    }
}