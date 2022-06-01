using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist.ItemPages
{
    public class EditWishlistItemPricePage
    {
        private const string PageTitleText = "Price";

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _pageTitle;

        [FindsBy(How = How.Id, Using = "titleTargetAmount")]
        private IWebElement _priceFieldLabel;

        [FindsBy(How = How.Id, Using = "userEditedAmount")]
        private IWebElement _priceInputField;

        [FindsBy(How = How.Id, Using = "iconCheckUseTax")]
        private IWebElement _estimateTaxCheckbox;

        [FindsBy(How = How.Id, Using = "labelUseEstimatedTax")]
        private IWebElement _estimateTaxLabel;

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _saveButton;

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        public EditWishlistItemPricePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public EditWishlistItemPricePage WaitUntilEditWishlistItemNamePriceIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pageTitle));
                    Wait.Until(ElementToBeVisible(_priceFieldLabel));
                    Wait.Until(ElementToBeVisible(_priceInputField));
                    Wait.Until(ElementToBeVisible(_estimateTaxCheckbox));
                    Wait.Until(ElementToBeVisible(_estimateTaxLabel));
                    Wait.Until(ElementToBeVisible(_saveButton));
                    Wait.Until(ElementToBeClickable(_cancelButton));

                    _cancelButton.Enabled.Should().BeTrue();
                    _pageTitle.Text.Should().Be(PageTitleText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }

        [AllureStep("Edit Wishlist Item Price")]
        public EditWishlistItemPricePage EditWishlistItemPrice(string amount)
        {
            WaitUntilEditWishlistItemNamePriceIsLoaded();
            CustomKeyboard.ClearInputField(_priceInputField);
            CustomKeyboard.SendKeys(amount);
            return this;
        }

        [AllureStep("Click 'Save' button")]
        public EditWishlistItemPricePage ClickSaveButton()
        {
            Wait.Until(ElementToBeVisible(_saveButton));
            _saveButton.Click();
            return this;
        }
    }
}