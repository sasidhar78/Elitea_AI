using NUnit.Framework;
using OpenQA.Selenium;

[Binding]
public class SauceDemoSteps
{
    private readonly IWebDriver driver;
    private readonly LoginPage loginPage;
    private readonly ProductPage productPage;

    public SauceDemoSteps(IWebDriver driver)
    {
        this.driver = driver;
        loginPage = new LoginPage(driver);
        productPage = new ProductPage(driver);
    }

    [Given("I am on the SauceDemo login page")]
    public void GivenIAmOnTheSauceDemoLoginPage()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com");
    }

    [When("I enter \"(.*)\" and \"(.*)\"")]
    public void WhenIEnterAnd(string username, string password)
    {
        loginPage.EnterUsername(username);
        loginPage.EnterPassword(password);
    }

    [When("I click the login button")]
    public void WhenIClickTheLoginButton()
    {
        loginPage.ClickLoginButton();
    }

    [Then("I should be redirected to the product page")]
    public void ThenIShouldBeRedirectedToTheProductPage()
    {
        Assert.IsTrue(productPage.IsProductPageDisplayed(), "User is not on the product page.");
    }
}