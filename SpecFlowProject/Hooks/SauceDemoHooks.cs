using FrameWorkLayer;
using OpenQA.Selenium;
using PageObjectModel.SauceDemo;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public sealed class SauceDemoHooks
    {
        private DriverUtility driverUtility;
        private WebUtilities webUtilities;
        private IWebDriver driver;
        private LoginPage loginPage;
        private Product product;
        private ItemPage itemPage;
        private CartPage cartPage;


        private ScenarioContext scenarioContext;

        public SauceDemoHooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [BeforeScenario("@VerifyvalidCredential", "@VerifyInvalidCredential", "@VerifyCart", "@verifyValidCredentials", "@verifyInvalidCredentials", "@VerifyCredentials")]
        public void BeforeScenario()
        {
            driverUtility = new DriverUtility();
            driver = driverUtility.GetDriver("Chrome");
            webUtilities = new WebUtilities(driver);
            loginPage = new LoginPage(webUtilities);
            product = new Product(webUtilities);
            itemPage = new ItemPage(webUtilities);
            cartPage = new CartPage(webUtilities);

            scenarioContext["webUtilities"] = webUtilities;
            scenarioContext["loginPage"] = loginPage;
            scenarioContext["product"] = product;
            scenarioContext["itemPage"] = itemPage;
            scenarioContext["cartPage"] = cartPage;

        }

        [AfterScenario("@VerifyvalidCredential", "@VerifyInvalidCredential", "@VerifyCart", "@verifyValidCredentials", "@verifyInvalidCredentials", "@VerifyCredentials")]
        public void AfterScenario()
        {
            webUtilities.Quit();
        }

    }
}