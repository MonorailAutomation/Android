using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

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

        public LoginPage PassCredentials(string email, string password)
        {
            WaitUntilLoginPageIsLoaded();
            _emailInput.Clear();
            _emailInput.SendKeys(email);
            _passwordInput.SendKeys(password);
            return this;
        }

        public LoginPage ClickSignInButton()
        {
            WaitUntilLoginPageIsLoaded();
            _signInButton.Click();
            return this;
        }

        public LoginPage ClickCreateAnAccountButton()
        {
            WaitUntilLoginPageIsLoaded();
            _createAnAccountButton.Click();
            return this;
        }

        private void WaitUntilLoginPageIsLoaded()
        {
            Waits.ElementToBeVisible(_emailInput);
            Waits.ElementToBeVisible(_passwordInput);
            Waits.ElementToBeClickable(_createAnAccountButton);
            Waits.ElementToBeClickable(_signInButton);
        }
    }
}