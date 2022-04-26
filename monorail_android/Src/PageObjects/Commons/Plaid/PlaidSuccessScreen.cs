using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Commons.Plaid
{
    public class PlaidSuccessScreen
    {
        private const string SuccessMessageText = "Success";

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'android.widget.Button') and contains(@text, 'Continue')]")]
        private IWebElement _continueButton;

        [FindsBy(How = How.XPath,
            Using = "//*[contains(@text, 'Your account has been successfully linked to Vimvest')]")]
        private IWebElement _informationMessage;

        [FindsBy(How = How.XPath, Using = "//*[contains(@resource-id, 'a11y-title')]")]
        private IWebElement _successMessage;

        public PlaidSuccessScreen(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public PlaidSuccessScreen ClickContinueButton()
        {
            WaitUntilPlaidSuccessScreenIsLoaded();
            _continueButton.Click();
            return this;
        }

        private void WaitUntilPlaidSuccessScreenIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_successMessage));
                    Wait.Until(ElementToBeVisible(_informationMessage));
                    Wait.Until(ElementToBeVisible(_continueButton));

                    _successMessage.Text.Should().Contain(SuccessMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}