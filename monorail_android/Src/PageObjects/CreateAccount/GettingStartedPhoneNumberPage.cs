using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.CreateAccount
{
    public class GettingStartedPhoneNumberPage
    {
        private const string PhoneNumberLabelText = "Your Phone Number";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "editField")]
        private IWebElement _phoneNumberInput;

        public GettingStartedPhoneNumberPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public GettingStartedPhoneNumberPage PassPhoneNumber(string phoneNumber)
        {
            WaitUntilPhoneNumberPageIsLoaded();
            _phoneNumberInput.SendKeys(phoneNumber);
            return this;
        }

        public GettingStartedPhoneNumberPage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) Waits.ElementToBeClickable(_continueButton);
            _continueButton.Click();
            return this;
        }

        private void WaitUntilPhoneNumberPageIsLoaded()
        {
            Waits.ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + PhoneNumberLabelText + "')]"));
            Waits.ElementToBeVisible(_phoneNumberInput);
            Waits.ElementToBeVisible(_continueButton);
        }
    }
}