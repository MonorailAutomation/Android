using System;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Money
{
    public class SpendSaveToggle
    {
        [FindsBy(How = How.Id, Using = "labelSave")]
        private IWebElement _saveButton;

        [FindsBy(How = How.Id, Using = "labelSpend")]
        private IWebElement _spendButton;

        public SpendSaveToggle(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Spend' button")]
        public SpendSaveToggle ClickSpendButton()
        {
            WaitUntilSpendSaveToggleIsLoaded();
            _spendButton.Click();
            return this;
        }

        [AllureStep("Click 'Save' button")]
        public SpendSaveToggle ClickSaveButton()
        {
            WaitUntilSpendSaveToggleIsLoaded();
            _saveButton.Click();
            return this;
        }

        private void WaitUntilSpendSaveToggleIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeClickable(_saveButton));
                    Wait.Until(ElementToBeClickable(_spendButton));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}