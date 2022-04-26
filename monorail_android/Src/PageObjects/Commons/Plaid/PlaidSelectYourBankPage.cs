using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Commons.Plaid
{
    public class PlaidSelectYourBankPage
    {
        public PlaidSelectYourBankPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public PlaidSelectYourBankPage ClickBank(string bank)
        {
            WaitUntilPlaidSelectYourBankPageIsLoaded();
            var bankSelector = "//*[contains(@class, 'Button') and contains(@text, '" + bank + "')]";
            var bankElement = Driver.FindElementByXPath(bankSelector);
            bankElement.Click();
            return this;
        }

        private static void WaitUntilPlaidSelectYourBankPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(Driver.FindElementByXPath("//*[contains(@text, 'Chase')]")));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}