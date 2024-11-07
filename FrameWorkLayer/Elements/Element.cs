using OpenQA.Selenium;

namespace LoginBDD.FrameworkLayer.Elements
{
    public abstract class ElementHandler
    {
        protected IWebDriver Driver;

        public ElementHandler(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebElement FindElement(By locator)
        {
            return Driver.FindElement(locator);
        }
    }
}