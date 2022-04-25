using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Commons.Plaid
{
    public class PlaidStartPage
    {
        [FindsBy(How = How.XPath, Using = "//*[contains(@resource-id, 'aut-continue-button')]")]
        private IWebElement _continueButton;

        public PlaidStartPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public PlaidStartPage ClickContinueButton()
        {
            WaitUntilPlaidStartPageIsLoaded();
            _continueButton.Click();
            return this;
        }

        private void WaitUntilPlaidStartPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_continueButton));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}