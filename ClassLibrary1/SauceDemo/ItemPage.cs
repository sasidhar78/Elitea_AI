using FrameWorkLayer;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.SauceDemo
{
    
    public class ItemPage
    {
        private readonly WebUtilities webUtility;

        public ItemPage(WebUtilities _webUtility)
        {
            this.webUtility = _webUtility;
        }
        private By addToCart = By.XPath("//button[text() = 'ADD TO CART']");

        private By cartIcon = By.XPath("//*[local-name()='svg']");

        public void AddToCart()
        {
            webUtility.Click(addToCart);
        }

        public void ClickCartIcon()
        {
            webUtility.Click(cartIcon);
        }
    }

    
}
