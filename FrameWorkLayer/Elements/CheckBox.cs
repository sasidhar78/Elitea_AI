using OpenQA.Selenium;

namespace LoginBDD.FrameworkLayer.Elements
{
    public class CheckboxHandler : ElementHandler
    {
        public CheckboxHandler(IWebDriver driver) : base(driver)
        {
        }

        public void ToggleCheckbox(By locator)
        {
            var checkbox = FindElement(locator);
            checkbox.Click();
        }

        public bool IsCheckboxChecked(By locator)
        {
            return FindElement(locator).Selected;
        }
    }
}