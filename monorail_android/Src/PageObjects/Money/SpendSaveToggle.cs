using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
namespace monorail_android.PageObjects.Money
{
    public class SpendSaveToggle
    {
        [FindsBy(How = How.Id, Using = "labelSpend")]
        private IWebElement _spendButton;
        
        [FindsBy(How = How.Id, Using = "labelSave")]
        private IWebElement _saveButton;

        public SpendSaveToggle(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public SpendSaveToggle ClickSpendButton()
        {
            _spendButton.Click();
            return this;
        }
        
        public SpendSaveToggle ClickSaveButton()
        {
            _saveButton.Click();
            return this;
        }
        
        public void WaitUntilSpendSaveToggleIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Waits.ElementToBeClickable(_saveButton);
                    Waits.ElementToBeClickable(_spendButton);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}