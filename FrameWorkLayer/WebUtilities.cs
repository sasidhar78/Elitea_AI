using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWorkLayer.ActionHelper;
using FrameWorkLayer.ScreenShot;
using FrameWorkLayer.WaitHelper;
using LoginBDD.FrameworkLayer.Elements;
using OpenQA.Selenium;

namespace FrameWorkLayer
{
    
    public  class WebUtilities : JavaScriptExecutor
    {
        private IWebDriver driver;        
        private TakeScreenShots takeScreenShots;      
        private Action_Helper action_Helper;
        private Wait_Helper waitHelper;

        private RadioButtonHandler radioBtn;



        public WebUtilities(IWebDriver _driver) : base(_driver) 
        {
            this.driver = _driver;     
            takeScreenShots = new TakeScreenShots(driver);       
            action_Helper = new Action_Helper(driver);
            waitHelper = new Wait_Helper(driver);
            radioBtn = new RadioButtonHandler(driver);

        }

        public IWebElement GetElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            waitHelper.ImplicitWait(10);
            driver.Manage().Window.Maximize();
        }
        public void ClearAndSendKeys(By locator , string text)
        {
            GetElement(locator).Clear();
            GetElement(locator).SendKeys(text);
        }

        public void Click(By locator)
        {
            GetElement(locator).Click();

        }

        public bool Url(string url)
        {
            return driver.Url.Contains(url);

        }

        public void Quit()
        {
            driver.Quit();
        }

        public bool Selected(By locator)
        {
            return GetElement(locator).Selected;
        }

       public void TakeScreenShot(string file)
        {
            takeScreenShots.TakeScreenShot(file);
        }

        //Actions
        public void Scrolling(int x1, int x2)
        {
            action_Helper.Scrolling(x1, x2);
        }

        public void HoverOverElement(By locator)
        {
            action_Helper.HoverOverElement(locator);
        }

        public void RightClickElement(By locator)
        {
            action_Helper.RightClickElement(locator);
        }

        public void DoubleClickElement(By locator)
        {
            action_Helper.DoubleClickElement(locator);
        }

        public void DragAndDrop(By sourceLocator, By targetLocator)
        {
            action_Helper.DragAndDrop(sourceLocator, targetLocator);
        }

        public void ReleaseClick(By locator)
        {
            action_Helper.ReleaseClick(locator);
        }

        public void SendKeysToElement(By locator, string keys)
        {
            action_Helper.SendKeysToElement(locator, keys);
        }

        public void ActionClick(By locator)
        {
            action_Helper.ActionClick(locator);
        }

        public void ImplicitWait(int sec)
        {
            waitHelper.ImplicitWait(sec);
        }

        public void WaitForElementVisible(By locator, int timeOutInSeconds)
        {
            waitHelper.WaitForElementVisible(locator, timeOutInSeconds);
        }

        public void WaitForElementClickable(By locator, int timeOutInSeconds)
        {
            waitHelper.WaitForElementClickable(locator, timeOutInSeconds);
        }

        public void WaitForElementsToBePresent(By locator, int timeOutInSeconds)
        {
            waitHelper.WaitForElementsToBePresent(locator, timeOutInSeconds);
        }

        public void FluentWait()
        {
            waitHelper.FluentWait();
        }



    }
}
