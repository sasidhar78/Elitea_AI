using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWorkLayer;
using OpenQA.Selenium;

namespace PageObjectModel.SauceDemo
{
    public class Product
    {
        private WebUtilities webUtilities;
        public Product(WebUtilities webUtilities)
        {
            this.webUtilities = webUtilities;
        }

        private By menu = By.XPath("//button[text() = 'Open Menu']");

        private By filter = By.XPath("//select[@class = 'product_sort_container']");

        private By product1 = By.XPath("//div[text()='Sauce Labs Backpack']");

        private By product1_AfterFilter = By.XPath("//div[text()='Sauce Labs Onesie']");

        private By lastProduct_AfterFilter = By.XPath("//div[text()='Sauce Labs Fleece Jacket']");

        private By dropDown = By.XPath("//select[@class='product_sort_container']");

        

        public void ApplyFilter(string text)
        {
            var element = webUtilities.GetElement(dropDown);
            /*webUtilities.SelectByText(text,element);*/
        }

        public void ClickFirstItem()
        {
            
            webUtilities.Click(product1_AfterFilter);
        }

        




    }
}
