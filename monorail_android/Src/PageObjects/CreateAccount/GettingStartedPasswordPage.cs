using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.CreateAccount
{
    public class GettingStartedPasswordPage
    {
        private const string NumberConditionLabelText = "At least 1 number";
        private const string UppercaseLetterConditionLabelText = "At least 1 uppercase letter";
        private const string SpecialCharacterLabelText = "At least 1 special character";
        private const string CharacterCountLabelText = "8 or more characters";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "editField")]
        private IWebElement _passwordInput;

        public GettingStartedPasswordPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public GettingStartedPasswordPage PassPassword(string password)
        {
            WaitUntilPasswordPageIsLoaded();
            _passwordInput.SendKeys(password);
            return this;
        }

        public GettingStartedPasswordPage ClickContinueButton()
        {
            WaitUntilPasswordPageIsLoaded();
            while (_continueButton.Enabled == false) Waits.ElementToBeClickable(_continueButton);
            _continueButton.Click();
            return this;
        }

        private static void WaitUntilPasswordPageIsLoaded()
        {
            Waits.ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + NumberConditionLabelText + "')]"));
            Waits.ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + UppercaseLetterConditionLabelText + "')]"));
            Waits.ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + SpecialCharacterLabelText + "')]"));
            Waits.ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + CharacterCountLabelText + "')]"));
        }
    }
}