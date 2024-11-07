using FrameWorkLayer;
using NUnit.Framework;
using PageObjectModel.TestAutomationWebsite;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class TestingTestAutomationWebsiteStepDefinitions
    {
        private WebUtilities webUtilities;
        private TestAutomationHomePage testHome;


        
        public TestingTestAutomationWebsiteStepDefinitions(WebUtilities webUtilities , TestAutomationHomePage testHome)
        {
            this.webUtilities = webUtilities;
            this.testHome = testHome;
        }
        [Given(@"I am on TestAutomation Website")]
        public void GivenIAmOnTestAutomationWebsite()
        {
            webUtilities.NavigateToUrl("https://testautomationpractice.blogspot.com/");
        }

        [When(@"I click on ""([^""]*)""")]
        public void WhenIClickOn(string male)
        {
            testHome.selectLocator(male);
            testHome.RadioButtonClick();
        }

        [Then(@"Radio button of male must be selected")]
        public void ThenRadioButtonOfMaleMustBeSelected()
        {
            Assert.IsTrue(testHome.RadioButtonSlected() , "Radio Button Not selected");
        }

        //checkBox

        [When(@"I select checkbox of ""([^""]*)""")]
        public void WhenISelectCheckboxOf(string sunday)
        {
            testHome.selectLocator(sunday);
            testHome.SelectCheckBox();
        }

        [Then(@"the check box must be selected")]
        public void ThenTheCheckBoxMustBeSelected()
        {
            Assert.IsTrue(testHome.CheckBoxSelected() , "CheckBox Not Selected");
        }

        //DropDown
        [When(@"I select dropdown of ""([^""]*)"" id and ""([^""]*)""")]
        public void WhenISelectDropdownOfIdAnd(string country, string value)
        {
            testHome.SelectDropDown(value);
        }

        [Then(@"DropDown must be selected as ""([^""]*)""")]
        public void ThenDropDownMustBeSelectedAs(string value)
        {
            Assert.IsTrue(testHome.DropDownSelected(value));
        }

        //Alerts

        [When(@"I click on alert of id ""([^""]*)""")]
        public void WhenIClickOnAlertOfId(string alertBtn)
        {
            testHome.AlertXpath(alertBtn);
            testHome.ChooseAlert();
        }

        [When(@"confirm the alert")]
        public void WhenConfirmTheAlert()
        {
            testHome.AlertOption();
        }

        [Then(@"Alert must be closed")]
        public void ThenAlertMustBeClosed()
        {
            Assert.IsTrue(testHome.AlertSelected(),"Alert Not Selected");
        }




    }
}
