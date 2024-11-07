using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LoginBDD.FrameworkLayer.Elements
{
    public class DropdownHandler : ElementHandler
    {
        public DropdownHandler(IWebDriver driver) : base(driver)
        {
        }

        public void SelectByValue(By locator, string value)
        {
            var selectElement = new SelectElement(FindElement(locator));
            selectElement.SelectByValue(value);
        }

        public void SelectByText(By locator, string text)
        {
            var selectElement = new SelectElement(FindElement(locator));
            selectElement.SelectByText(text);
        }

        public void SelectByIndex(By locator, int index)
        {
            var selectElement = new SelectElement(FindElement(locator));
            selectElement.SelectByIndex(index);
        }

        public string GetSelectedDropdownText(By locator)
        {
            var selectElement = new SelectElement(FindElement(locator));
            return selectElement.SelectedOption.Text;
        }
    }
}