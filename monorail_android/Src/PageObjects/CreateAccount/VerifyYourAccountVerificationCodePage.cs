using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.CreateAccount
{
    public class VerifyYourAccountVerificationCodePage
    {
        private const string VerificationCodeLabelText = "Please enter your verification code";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "editField")]
        private IWebElement _verificationCodeInput;

        public VerifyYourAccountVerificationCodePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public VerifyYourAccountVerificationCodePage PassVerificationCode(string verificationCode)
        {
            WaitUntilVerificationCodePageIsLoaded();
            _verificationCodeInput.SendKeys(verificationCode);
            return this;
        }

        public VerifyYourAccountVerificationCodePage ClickContinueButton()
        {
            WaitUntilVerificationCodePageIsLoaded();
            while (_continueButton.Enabled == false) Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }

        private void WaitUntilVerificationCodePageIsLoaded()
        {
            Wait.Until(ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + VerificationCodeLabelText + "')]")));
            Wait.Until(ElementToBeVisible(_verificationCodeInput));
            Wait.Until(ElementToBeVisible(_continueButton));
        }
    }
}