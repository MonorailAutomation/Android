using System;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;

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
            var bankSelector = "//*[contains(@text, '" + bank + "')]";
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
                    Waits.ElementToBeVisible(Driver.FindElementByXPath("//*[contains(@text, 'Chase')]"));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}