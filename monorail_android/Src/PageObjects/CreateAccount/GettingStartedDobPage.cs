using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;

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

        public GettingStartedDobPage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) Waits.ElementToBeClickable(_continueButton);
            _continueButton.Click();
            return this;
        }

        private void WaitUntilDateOfBirthPageIsLoaded()
        {
            Waits.ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + DobLabelText + "')]"));
            Waits.ElementToBeVisible(_monthPickerWheel);
            Waits.ElementToBeVisible(_dayPickerWheel);
            Waits.ElementToBeVisible(_yearPickerWheel);
        }
    }
}