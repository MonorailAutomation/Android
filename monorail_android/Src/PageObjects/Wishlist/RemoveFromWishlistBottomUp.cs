using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist
{
    public class RemoveFromWishlistBottomUp
    {
        private const string BottomUpHeaderText = "Remove from Wishlist";
        private const string BottomUpMessageText = "Are you sure you want to remove this Wishlist item?";

        [FindsBy(How = How.Id, Using = "labelTitle")]
        private IWebElement _bottomUpHeader;

        [FindsBy(How = How.Id, Using = "labelText")]
        private IWebElement _bottomUpMessage;

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "buttonConfirm")]
        private IWebElement _removeButton;

        public RemoveFromWishlistBottomUp(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public RemoveFromWishlistBottomUp ClickRemoveButton()
        {
            WaitUntilRemoveFromWishlistBottomUpIsLoaded();
            _removeButton.Click();
            return this;
        }

        private RemoveFromWishlistBottomUp WaitUntilRemoveFromWishlistBottomUpIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_bottomUpHeader));
                    Wait.Until(ElementToBeVisible(_bottomUpMessage));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_removeButton));

                    _bottomUpHeader.Text.Should().Contain(BottomUpHeaderText);
                    _bottomUpMessage.Text.Should().Contain(BottomUpMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }
    }
}