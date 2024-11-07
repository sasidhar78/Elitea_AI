using FrameWorkLayer;
using PageObjectModel.SauceDemo;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class VerifyLoginPageStepDefinitions
    {
        private readonly WebUtilities webUtilities;
        private LoginPage loginPage;
        private Product product;
        private ItemPage itemPage;
        private CartPage cartPage;


        public VerifyLoginPageStepDefinitions(ScenarioContext scenarioContext)
        {
            webUtilities = scenarioContext["webUtilities"] as WebUtilities;
            loginPage = scenarioContext["loginPage"] as LoginPage;
            product = scenarioContext["product"] as Product;
            itemPage = scenarioContext["itemPage"] as ItemPage;
            cartPage = scenarioContext["cartPage"] as CartPage;

        }

        [Given(@"I am on SauceDemo website login page")]
        public void GivenIAmOnSauceDemoWebsiteLoginPage()
        {
            webUtilities.NavigateToUrl("https://www.saucedemo.com/v1/");
        }

        [When(@"I enter ""([^""]*)"" and ""([^""]*)""")]
        public void WhenIEnterAnd(string p0, string p1)
        {
            loginPage.EnterUserName(p0);
            loginPage.EnterPassword(p1);
        }

        [When(@"I click on login button")]
        public void WhenIClickOnLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"I must enter into SauceDemo website")]
        public void ThenIMustEnterIntoSauceDemoWebsite()
        {
            Assert.IsTrue(webUtilities.Url("https://www.saucedemo.com/v1/inventory.html"),"Didn't go to expected page");
            
        }

        [Then(@"I should not enter into SauceDemo website")]
        public void ThenIShouldNotEnterIntoSauceDemoWebsite()
        {
            Assert.IsTrue(webUtilities.Url("https://www.saucedemo.com/v1/"),"Error");
        }

        [When(@"I select the DropDown by text ""([^""]*)""")]
        public void WhenISelectTheDropDownByText(string p0)
        {
            product.ApplyFilter(p0);
        }

        [When(@"Click on the first product")]
        public void WhenClickOnTheFirstProduct()
        {
            product.ClickFirstItem();
        }

        [When(@"I click Add to cart")]
        public void WhenIClickAddToCart()
        {
            itemPage.AddToCart();
            itemPage.ClickCartIcon();
        }

        [Then(@"element must be visible in cart")]
        public void ThenElementMustBeVisibleInCart()
        {
            Assert.IsTrue(cartPage.IsElementPresent(),"element didn't found");
        }

        [When(@"I enter username and password as ""([^""]*)"" and ""([^""]*)""")]
        public void WhenIEnterUsernameAndPasswordAsAnd(string username, string password)
        {
            loginPage.EnterUserName(username);
            loginPage.EnterPassword(password);
        }

        [When(@"I should take the Screenshot")]
        public void WhenIShouldTakeTheScreenshot()
        {
            webUtilities.TakeScreenShot("product.png");
        }




    }
}
