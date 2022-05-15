using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist
{
    public class CompleteYourItemDescriptionPage
    {
        private const string DescriptionInputPlaceholderText = "Write a description...";

        private const string PageHeaderText = "Complete your Item info";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _pageHeader;

        [FindsBy(How = How.Id, Using = "editDescription")]
        private IWebElement _wishlistItemDescriptionInput;

        public CompleteYourItemDescriptionPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public CompleteYourItemDescriptionPage ClickContinueButton()
        {
            Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }

        public CompleteYourItemDescriptionPage SetWishlistItemDescription(string wishlistItemDescription)
        {
            WaitUntilCompleteYourItemDescriptionPageIsLoaded();
            Wait.Until(ElementToBeVisible(_wishlistItemDescriptionInput));
            _wishlistItemDescriptionInput.SendKeys(wishlistItemDescription);
            return this;
        }

        private void WaitUntilCompleteYourItemDescriptionPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pageHeader));
                    Wait.Until(ElementToBeVisible(_wishlistItemDescriptionInput));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_continueButton));

                    _pageHeader.Text.Should().Contain(PageHeaderText);
                    _wishlistItemDescriptionInput.Text.Should().Contain(DescriptionInputPlaceholderText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}