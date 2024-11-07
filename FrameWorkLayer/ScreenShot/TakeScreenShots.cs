using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkLayer.ScreenShot
{
    public class TakeScreenShots
    {
        private IWebDriver driver;

        public TakeScreenShots(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void TakeScreenShot(string fileName)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string filePath = Path.Combine(AppContext.BaseDirectory, fileName);
            Console.WriteLine(filePath);
            File.WriteAllBytes(filePath, ss.AsByteArray);
        }
    }
}
