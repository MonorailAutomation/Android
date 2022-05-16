using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "buttonCreateAccount")]
        private IWebElement _createAnAccountButton;

        [FindsBy(How = How.Id, Using = "editEmail")]
        private IWebElement _emailInput;

        [FindsBy(How = How.Id, Using = "editPassword")]
        private IWebElement _passwordInput;

        [FindsBy(How = How.Id, Using = "buttonSignIn")]
        private IWebElement _signInButton;

        public LoginPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Login with username: '{0}' and password: '{1}'")]
        public LoginPage PassCredentials(string email, string password)
        {
            WaitUntilLoginPageIsLoaded();
            _emailInput.Clear();
            _emailInput.SendKeys(email);
            _passwordInput.SendKeys(password);
            return this;
        }

        [AllureStep("Click 'Sign In' button")]
        public LoginPage ClickSignInButton()
        {
            WaitUntilLoginPageIsLoaded();
            _signInButton.Click();
            return this;
        }

        [AllureStep("Click 'Create An Account' button")]
        public LoginPage ClickCreateAnAccountButton()
        {
            WaitUntilLoginPageIsLoaded();
            _createAnAccountButton.Click();
            return this;
        }

        private void WaitUntilLoginPageIsLoaded()
        {
            Wait.Until(ElementToBeVisible(_emailInput));
            Wait.Until(ElementToBeVisible(_passwordInput));
            Wait.Until(ElementToBeClickable(_createAnAccountButton));
            Wait.Until(ElementToBeVisible(_signInButton));
        }
    }
}