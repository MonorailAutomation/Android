using System;
using FluentAssertions;
using monorail_android.Commons;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Commons.EditPages
{
    public class EditPricePage
    {
        private const string PricePageTitleText = "Price";
        private const string PricePageLabelText = "Price";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "titleTargetAmount")]
        private IWebElement _priceLabel;

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _pricePageTitle;

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _saveButton;

        public EditPricePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Save' button")]
        public EditPricePage ClickSaveButton()
        {
            while (_saveButton.Enabled == false) Wait.Until(ElementToBeClickable(_saveButton));
            _saveButton.Click();
            return this;
        }

        [AllureStep("Set item's price to: {0}")]
        public EditPricePage SetPrice(string price)
        {
            CustomKeyboard.SendKeys(price);
            return this;
        }

        private void WaitUntilPricePageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pricePageTitle));
                    Wait.Until(ElementToBeVisible(_priceLabel));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_saveButton));

                    _pricePageTitle.Text.Should().Contain(PricePageTitleText);
                    _priceLabel.Text.Should().Contain(PricePageLabelText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}