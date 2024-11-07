using FrameWorkLayer;
using LoginBDD.FrameworkLayer.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Chrome;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.TestAutomationWebsite
{
    public class TestAutomationHomePage
    {
        private WebUtilities webUtilities;
        private RadioButtonHandler radioBtn;
        private CheckboxHandler checkBtn;
        private DropdownHandler dropDownHandle;
        private IWebDriver driver;

        public TestAutomationHomePage(IWebDriver driver,WebUtilities webUtilities, RadioButtonHandler radioBtn , CheckboxHandler checkBtn, DropdownHandler dropDownHandle)
        {
            this.webUtilities = webUtilities;
            this.radioBtn = radioBtn;
            this.checkBtn = checkBtn;
            this.dropDownHandle = dropDownHandle;
            this.driver = driver;
        }


       
        private By Xpath;
        private By dropDownXpath = By.XPath("//select[@class = 'form-control' and @id = 'country']");
        private By AlertXPath;


        //RadioButton
        public void selectLocator(string value)
        {
            Xpath = By.XPath($"//input[contains(@class , 'form-check-input') and @id = '{value}']");
        }

        public void RadioButtonClick()
        {
            radioBtn.SelectRadioButton(Xpath);
        }

        public bool RadioButtonSlected()
        {
            return radioBtn.IsRadioButtonSelected(Xpath);
        }

        // checkBox

        public void SelectCheckBox()
        {
            checkBtn.ToggleCheckbox(Xpath);
        }

        public bool CheckBoxSelected()
        {
            return checkBtn.IsCheckboxChecked(Xpath);
        }

        

        //DropDown

        public void SelectDropDown(string value)
        {
            webUtilities.Scroll(0,700);
            dropDownHandle.SelectByText(dropDownXpath, value);
        }

        public bool DropDownSelected(string value)
        {
            string str = dropDownHandle.GetSelectedDropdownText(dropDownXpath);

            if(str == value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Alert

        public void AlertXpath(string value)
        {
            AlertXPath = By.Id($"{value}");
        }
        public void ChooseAlert()
        {
            webUtilities.Click(AlertXPath);
        }

        public void AlertOption()
        {
            
            WindowFrameAlertUtilities.HandleAlert(driver);
        }

        public bool AlertSelected()
        {
            return true;
        }
    }
}
