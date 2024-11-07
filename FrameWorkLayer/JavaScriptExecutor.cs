using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkLayer
{
    public class JavaScriptExecutor
    {
        private IWebDriver driver;
        private JavaScriptExecutor js;

        public JavaScriptExecutor(IWebDriver driver)
        {
            this.driver = driver;
            
        }

        
        
        public void Scroll(int n1 , int n2)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy({n1} , {n2});");
        }
    }
}
