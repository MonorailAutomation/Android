using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.CreateAccount
{
    public class GettingStartedEmailPage
    {
        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "editField")]
        private IWebElement _emailInput;

        public GettingStartedEmailPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public GettingStartedEmailPage PassEmail(string email)
        {
            Wait.Until(ElementToBeVisible(_emailInput));
            _emailInput.SendKeys(email);
            return this;
        }

        public GettingStartedEmailPage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }
    }
}