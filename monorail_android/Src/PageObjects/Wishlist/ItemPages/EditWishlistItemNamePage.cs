using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist.ItemPages
{
    public class EditWishlistItemNamePage
    {
        private const string PageTitleText = "Name";

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _pageTitle;

        [FindsBy(How = How.Id, Using = "label")]
        private IWebElement _nameFieldLabel;

        [FindsBy(How = How.Id, Using = "textField")]
        private IWebElement _nameInputField;

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _saveButton;

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        public EditWishlistItemNamePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public EditWishlistItemNamePage WaitUntilEditWishlistItemNamePageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pageTitle));
                    Wait.Until(ElementToBeVisible(_nameFieldLabel));
                    Wait.Until(ElementToBeVisible(_nameInputField));
                    Wait.Until(ElementToBeVisible(_saveButton));
                    Wait.Until(ElementToBeClickable(_cancelButton));

                    _saveButton.Enabled.Should().BeFalse();
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

        [AllureStep("Edit Wishlist Item Name")]
        public EditWishlistItemNamePage EditWishlistItemName(string name)
        {
            WaitUntilEditWishlistItemNamePageIsLoaded();
            _nameInputField.Clear();
            _nameInputField.SendKeys(name);
            return this;
        }

        [AllureStep("Click 'Save' button")]
        public EditWishlistItemNamePage ClickSaveButton()
        {
            Wait.Until(ElementToBeVisible(_saveButton));
            _saveButton.Click();
            return this;
        }
    }
}