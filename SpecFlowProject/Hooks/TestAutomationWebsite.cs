using BoDi;
using FrameWorkLayer;
using LoginBDD.FrameworkLayer.Elements;
using OpenQA.Selenium;
using PageObjectModel.TestAutomationWebsite;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public sealed class TestAutomationWebsite
    {
        private IWebDriver driver;
        private DriverUtility driverUtility;
        private WebUtilities webUtilities;
        private RadioButtonHandler RadioBtn;
        private CheckboxHandler checkBtn;
        private DropdownHandler dropDownHandle;
        private TestAutomationHomePage testHome;
        private IObjectContainer container;

        public TestAutomationWebsite(IObjectContainer container)
        {
            this.container = container;
        }



        [BeforeScenario("@RadioButton" , "@CheckBox", "@CheckDropDown", "@Alerts")]
        public void BeforeScenarioWithTag()
        {
            driverUtility = new DriverUtility();
            driver = driverUtility.GetDriver("Chrome");
            webUtilities = new WebUtilities(driver);
            RadioBtn = new RadioButtonHandler(driver);
            checkBtn = new CheckboxHandler(driver);
            dropDownHandle = new DropdownHandler(driver);
            testHome = new TestAutomationHomePage(driver,webUtilities , RadioBtn , checkBtn , dropDownHandle);

            container.RegisterInstanceAs<TestAutomationHomePage>(testHome);
            container.RegisterInstanceAs<WebUtilities>(webUtilities);
          
        }

        

        [AfterScenario("@RadioButton", "@CheckBox", "@CheckDropDown", "@Alerts")]
        public void AfterScenario()
        {
            webUtilities.Quit();
        }
    }
}