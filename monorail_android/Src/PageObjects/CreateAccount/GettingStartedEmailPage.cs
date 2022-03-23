using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

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
            Waits.ElementToBeVisible(_emailInput);
            _emailInput.SendKeys(email);
            return this;
        }

        public GettingStartedEmailPage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) Waits.ElementToBeClickable(_continueButton);
            _continueButton.Click();
            return this;
        }
    }
}