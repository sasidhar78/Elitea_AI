using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FrameWorkLayer;

namespace PageObjectModel.SauceDemo
{
    public class LoginPage
    {
        private readonly WebUtilities webUtility;

        public LoginPage(WebUtilities _webUtility)
        {
            this.webUtility = _webUtility;
        }

       

        private By userName = By.Id("user-name");
        private By password = By.Id("password");
        private By loginButton = By.Id("login-button");

        public void EnterUserName(string text)
        {
            webUtility.ClearAndSendKeys(userName , text);
        }

        public void EnterPassword(string text)
        {
            webUtility.ClearAndSendKeys(password , text);
        }

        public void ClickLoginButton()
        {
            webUtility.Click(loginButton);
        }
    }
}
