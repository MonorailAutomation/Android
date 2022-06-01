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
    public class EditWishlistItemDescriptionPage
    {
        private const string PageTitleText = "Description";

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _pageTitle;

        [FindsBy(How = How.Id, Using = "label")]
        private IWebElement _descriptionFieldLabel;

        [FindsBy(How = How.Id, Using = "textField")]
        private IWebElement _descriptionInputField;

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _saveButton;

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        public EditWishlistItemDescriptionPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public EditWishlistItemDescriptionPage WaitUntilEditWishlistItemDescriptionPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pageTitle));
                    Wait.Until(ElementToBeVisible(_descriptionFieldLabel));
                    Wait.Until(ElementToBeVisible(_descriptionInputField));
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

        [AllureStep("Edit Wishlist Item Description")]
        public EditWishlistItemDescriptionPage EditWishlistItemDescription(string name)
        {
            WaitUntilEditWishlistItemDescriptionPageIsLoaded();
            _descriptionInputField.Clear();
            _descriptionInputField.SendKeys(name);
            return this;
        }

        [AllureStep("Click 'Save' button")]
        public EditWishlistItemDescriptionPage ClickSaveButton()
        {
            Wait.Until(ElementToBeVisible(_saveButton));
            _saveButton.Click();
            return this;
        }
    }
}