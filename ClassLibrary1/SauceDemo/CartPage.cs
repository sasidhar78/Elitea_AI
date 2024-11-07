using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWorkLayer;
using OpenQA.Selenium;

namespace PageObjectModel.SauceDemo
{
    public class CartPage
    {
        private WebUtilities webUtilities;
        public CartPage(WebUtilities webUtilities)
        {
            this.webUtilities = webUtilities;
        }
        private By product = By.XPath("//div[text()='Sauce Labs Onesie']");
        public bool IsElementPresent()
        {
            try
            {

                webUtilities.GetElement(product);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
