using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

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

        [AllureStep("Pass password: '{0}'")]
        public GettingStartedPasswordPage PassPassword(string password)
        {
            WaitUntilPasswordPageIsLoaded();
            _passwordInput.SendKeys(password);
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public GettingStartedPasswordPage ClickContinueButton()
        {
            WaitUntilPasswordPageIsLoaded();
            while (_continueButton.Enabled == false) Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }

        private static void WaitUntilPasswordPageIsLoaded()
        {
            Wait.Until(ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + NumberConditionLabelText + "')]")));
            Wait.Until(ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + UppercaseLetterConditionLabelText + "')]")));
            Wait.Until(ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + SpecialCharacterLabelText + "')]")));
            Wait.Until(ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + CharacterCountLabelText + "')]")));
        }
    }
}