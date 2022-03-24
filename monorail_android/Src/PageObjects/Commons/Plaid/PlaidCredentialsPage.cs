using System;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace monorail_android.PageObjects.Commons.Plaid
{
    public class PlaidCredentialsPage
    {
        [FindsBy(How = How.XPath, Using = "//*[contains(@resource-id, 'password')]")]
        private IWebElement _passwordInput;

        [FindsBy(How = How.XPath, Using = "//*[contains(@resource-id, 'aut-submit-button')]")]
        private IWebElement _submitButton;

        [FindsBy(How = How.XPath, Using = "//*[contains(@resource-id, 'username')]")]
        private IWebElement _usernameInput;

        public PlaidCredentialsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public PlaidCredentialsPage PassCredentials()
        {
            WaitUntilPlaidCredentialsPageIsLoaded();
            _usernameInput.SendKeys("user_good");
            _passwordInput.SendKeys("pass_good");
            return this;
        }

        public PlaidCredentialsPage ClickSubmitButton()
        {
            _submitButton.Click();
            return this;
        }

        private void WaitUntilPlaidCredentialsPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Waits.ElementToBeVisible(_usernameInput);
                    Waits.ElementToBeVisible(_passwordInput);
                    Waits.ElementToBeVisible(_submitButton);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}