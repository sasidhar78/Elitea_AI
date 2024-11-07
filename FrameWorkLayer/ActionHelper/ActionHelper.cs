using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkLayer.ActionHelper
{
   public class Action_Helper
    {
        private readonly IWebDriver driver;
        private readonly Actions action;

        // Constructor
        public Action_Helper(IWebDriver driver)
        {
            this.driver = driver;
            action = new Actions(this.driver);
        }

        public void Scrolling(int x1, int x2)
        {
            action.ScrollByAmount(x1, x2).Perform();
            Thread.Sleep(2000);
        }

        // Method to perform mouse hover action
        public void HoverOverElement(By locator)
        {
            var element = driver.FindElement(locator);
            action.MoveToElement(element).Perform();
        }

        // Method to perform right-click (context-click) action
        public void RightClickElement(By locator)
        {
            var element = driver.FindElement(locator);
            action.ContextClick(element).Perform();
        }

        // Method to perform double-click action
        public void DoubleClickElement(By locator)
        {
            var element = driver.FindElement(locator);
            action.DoubleClick(element).Perform();
        }

        // Method to perform drag-and-drop action
        public void DragAndDrop(By sourceLocator, By targetLocator)
        {
            var sourceElement = driver.FindElement(sourceLocator);
            var targetElement = driver.FindElement(targetLocator);
            action.DragAndDrop(sourceElement, targetElement).Perform();
        }

        // Method to perform click and hold action
        public void ClickAndHold(By locator)
        {
            var element = driver.FindElement(locator);
            action.ClickAndHold(element).Perform();
        }

        // Method to release click and hold
        public void ReleaseClick(By locator)
        {
            var element = driver.FindElement(locator);
            action.Release(element).Perform();
        }

        // Method to send keys using Actions
        public void SendKeysToElement(By locator, string keys)
        {
            var element = driver.FindElement(locator);
            action.MoveToElement(element).SendKeys(keys).Perform();
        }

        public void ActionClick(By locator)
        {
            var element = driver.FindElement(locator);
            action.Click(element).Perform();
        }
    }
}
