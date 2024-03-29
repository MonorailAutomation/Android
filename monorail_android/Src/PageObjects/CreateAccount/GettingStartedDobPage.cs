using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.CreateAccount
{
    public class GettingStartedDobPage
    {
        private const string DobLabelText = "Your Date of Birth";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.XPath, Using = "//android.widget.NumberPicker[2]/android.widget.EditText")]
        private IWebElement _dayPickerWheel;

        [FindsBy(How = How.XPath, Using = "//android.widget.NumberPicker[1]/android.widget.EditText")]
        private IWebElement _monthPickerWheel;

        [FindsBy(How = How.XPath, Using = "//android.widget.NumberPicker[3]/android.widget.EditText")]
        private IWebElement _yearPickerWheel;

        public GettingStartedDobPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Set month: '{0}'")]
        public GettingStartedDobPage SetMonth(string expectedMonth)
        {
            WaitUntilDateOfBirthPageIsLoaded();
            var currentMonthOnPickerWheel = _monthPickerWheel.Text;
            while (!currentMonthOnPickerWheel.Equals(expectedMonth))
            {
                var upperButton =
                    Driver.FindElementByXPath("//android.widget.NumberPicker[1]/android.widget.Button[1]");
                upperButton.Click();
                currentMonthOnPickerWheel = _monthPickerWheel.Text;
            }

            return this;
        }

        [AllureStep("Set day: '{0}'")]
        public GettingStartedDobPage SetDay(string expectedDay)
        {
            WaitUntilDateOfBirthPageIsLoaded();
            var currentDayOnPickerWheel = _dayPickerWheel.Text;
            while (!currentDayOnPickerWheel.Equals(expectedDay))
            {
                var upperButton =
                    Driver.FindElementByXPath("//android.widget.NumberPicker[2]/android.widget.Button[1]");
                upperButton.Click();
                currentDayOnPickerWheel = _dayPickerWheel.Text;
            }

            return this;
        }

        [AllureStep("Set year: '{0}'")]
        public GettingStartedDobPage SetYear(string expectedYear)
        {
            WaitUntilDateOfBirthPageIsLoaded();
            var currentYearOnPickerWheel = _yearPickerWheel.Text;
            while (!currentYearOnPickerWheel.Equals(expectedYear))
            {
                var upperButton =
                    Driver.FindElementByXPath("//android.widget.NumberPicker[3]/android.widget.Button[1]");
                upperButton.Click();
                currentYearOnPickerWheel = _yearPickerWheel.Text;
            }

            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public GettingStartedDobPage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }

        private void WaitUntilDateOfBirthPageIsLoaded()
        {
            Wait.Until(ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + DobLabelText + "')]")));
            Wait.Until(ElementToBeVisible(_monthPickerWheel));
            Wait.Until(ElementToBeVisible(_dayPickerWheel));
            Wait.Until(ElementToBeVisible(_yearPickerWheel));
        }
    }
}