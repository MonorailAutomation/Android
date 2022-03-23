using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.CreateAccount
{
    public class VerifyYourAccountMethodPage
    {
        private const string FastestWayToVerifyLabelText = "Text Message is the fastest way to verify.";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.XPath, Using = "//*[contains(@text, 'Email')]")]
        private IWebElement _emailOption;

        [FindsBy(How = How.XPath, Using = "//*[contains(@text, 'Text message')]")]
        private IWebElement _textMessageOption;

        public VerifyYourAccountMethodPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public VerifyYourAccountMethodPage ClickTextMessageOption()
        {
            WaitUntilMethodPageIsLoaded();
            _textMessageOption.Click();
            return this;
        }
        
        public VerifyYourAccountMethodPage ClickEmailOption()
        {
            WaitUntilMethodPageIsLoaded();
            _emailOption.Click();
            return this;
        }

        public VerifyYourAccountMethodPage ClickContinue()
        {
            WaitUntilMethodPageIsLoaded();
            _continueButton.Click();
            return this;
        }

        private void WaitUntilMethodPageIsLoaded()
        {
            Waits.ElementToBeVisible(
                Driver.FindElementByXPath("//*[contains(@text, '" + FastestWayToVerifyLabelText + "')]"));
            Waits.ElementToBeVisible(_textMessageOption);
            Waits.ElementToBeVisible(_emailOption);
            Waits.ElementToBeVisible(_continueButton);
        }
    }
}