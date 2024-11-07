using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkLayer.WaitHelper
{
    public class Wait_Helper
    {
        private readonly IWebDriver driver;

        public Wait_Helper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForElementVisible(By locator, int timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
        public void WaitForElementClickable(By locator, int timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed && element.Enabled;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

        }

        public void WaitForElementsToBePresent(By locator, int timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(driver => driver.FindElements(locator).Count > 0);
        }

        public void WaitForElementToBeDisappear(By locator, int timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        public void ImplicitWait(int sec)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);
        }

        public void FluentWait()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(10),
                PollingInterval = TimeSpan.FromMilliseconds(10)
            };

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element = wait.Until(x => x.FindElement(By.Id("someid")));
        }
    }
}
