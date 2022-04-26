using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;
using static monorail_android.Commons.Constants;

namespace monorail_android.PageObjects.Commons.Plaid
{
    public class PlaidCredentialsPage
    {
        [FindsBy(How = How.XPath, Using = "//android.view.View[2]/android.widget.EditText")]
        private IWebElement _passwordInput;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'android.widget.Button') and contains(@text, 'Submit')]")]
        private IWebElement _submitButton;

        [FindsBy(How = How.XPath, Using = "//android.view.View[1]/android.widget.EditText")]
        private IWebElement _usernameInput;

        public PlaidCredentialsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public PlaidCredentialsPage PassCredentials()
        {
            WaitUntilPlaidCredentialsPageIsLoaded();
            _usernameInput.SendKeys(PlaidUsername);
            _passwordInput.SendKeys(PlaidPassword);
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
                    Wait.Until(ElementToBeVisible(_usernameInput));
                    Wait.Until(ElementToBeVisible(_passwordInput));
                    Wait.Until(ElementToBeVisible(_submitButton));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}