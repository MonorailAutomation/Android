using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist
{
    public class MainWishlistPage
    {
        [FindsBy(How = How.Id, Using = "iconPlus")]
        private IWebElement _addAnItemButton;

        [FindsBy(How = How.Id, Using = "buttonHowItWorks")]
        private IWebElement _howItWorksButton;

        [FindsBy(How = How.XPath, Using = "//android.widget.FrameLayout[3]//*[contains(@resource-id, 'groupNoItem')]")]
        private IWebElement _placeholder;

        [FindsBy(How = How.Id, Using = "buttonCreateAccount")]
        private IWebElement _createAWishlistAccountButton;

        public MainWishlistPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MainWishlistPage ClickWishlistItem(string wishlistItemName)
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    var wishlistItemSelector = "//*[contains(@text, '" + wishlistItemName + "')]";
                    var wishlistItemElement = Driver.FindElementByXPath(wishlistItemSelector);

                    Wait.Until(ElementToBeVisible(wishlistItemElement));
                    wishlistItemElement.Click();
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }

        public MainWishlistPage CheckIfWishlistItemIsDisplayedOnMainScreen(string wishlistItemName)
        {
            var wishlistItemSelector = "//*[contains(@text, '" + wishlistItemName + "')]";
            var wishlistItemElement = Driver.FindElementByXPath(wishlistItemSelector);
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(wishlistItemElement));

                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }

        public MainWishlistPage CheckStatusPillForWishlistItem(string wishlistItemName, string statusPillDescription)
        {
            var wishlistItemPillSelector = "//*[contains(@text, '" + wishlistItemName +
                                           "')]/following-sibling::*[contains(@resource-id, 'itemReadyToBuy')]";
            var wishlistItemPillElement = Driver.FindElementByXPath(wishlistItemPillSelector);
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(wishlistItemPillElement));

                    wishlistItemPillElement.Text.Should().Be(statusPillDescription);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }

        public MainWishlistPage ClickAddAnItemButton()
        {
            Wait.Until(ElementToBeVisible(_addAnItemButton));
            _addAnItemButton.Click();
            return this;
        }

        public MainWishlistPage ClickCreateAWishlistAccountButton()
        {
            Wait.Until(ElementToBeVisible(_createAWishlistAccountButton));
            _createAWishlistAccountButton.Click();
            return this;
        }

        public MainWishlistPage ClickPlaceholder()
        {
            Wait.Until(ElementToBeVisible(_placeholder));
            _placeholder.Click();
            return this;
        }
    }
}