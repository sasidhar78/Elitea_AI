using OpenQA.Selenium;

namespace LoginBDD.FrameworkLayer.Elements
{
    public class RadioButtonHandler : ElementHandler
    {
        public RadioButtonHandler(IWebDriver driver) : base(driver)
        {
        }

        public void SelectRadioButton(By locator)
        {
            var radioButton = FindElement(locator);
            if (!radioButton.Selected)
            {
                radioButton.Click();
            }
        }

        public bool IsRadioButtonSelected(By locator)
        {
            return FindElement(locator).Selected;
        }
    }
}