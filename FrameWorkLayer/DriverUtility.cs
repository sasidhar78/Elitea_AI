using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace FrameWorkLayer
{
    public class DriverUtility
    {
        private IWebDriver driver;

        public IWebDriver GetDriver(string browser)
        {
            browser = browser.ToLower();

            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    return driver;

                case "edge":
                    driver = new EdgeDriver();
                    return driver;
                default:
                    return null;

            }

        }


    }
}
