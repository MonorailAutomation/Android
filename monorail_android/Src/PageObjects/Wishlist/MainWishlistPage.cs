using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
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

        [FindsBy(How = How.Id, Using = "buttonBack")]
        private IWebElement _backButton;

        [FindsBy(How = How.Id, Using = "toggleImage")]
        private IWebElement _mainMenuButton;

        [FindsBy(How = How.Id, Using = "buttonCreateAccount")]
        private IWebElement _createAWishlistAccountButton;

        [FindsBy(How = How.Id, Using = "buttonHowItWorks")]
        private IWebElement _howItWorksButton;

        [FindsBy(How = How.XPath, Using = "//android.widget.FrameLayout[3]//*[contains(@resource-id, 'groupNoItem')]")]
        private IWebElement _placeholder;

        [FindsBy(How = How.Id, Using = "buttonNeedsCompletion")]
        private IWebElement _tapToCompleteItemPill;

        [FindsBy(How = How.Id, Using = "buttonManageCash")]
        private IWebElement _manageButton;

        public MainWishlistPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click Wishlist Item: '{0}'")]
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

        [AllureStep("Check if Wishlist Item '{0}' is displayed on Main Screen")]
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

        [AllureStep("Check if Wishlist Item '{0}' has '{1}' status pill")]
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

        [AllureStep("Click 'Add an Item' button")]
        public MainWishlistPage ClickAddAnItemButton()
        {
            Wait.Until(ElementToBeVisible(_addAnItemButton));
            _addAnItemButton.Click();
            return this;
        }

        [AllureStep("Click 'Back' button")]
        public MainWishlistPage ClickBackButton()
        {
            Wait.Until(ElementToBeVisible(_backButton));
            _backButton.Click();
            return this;
        }

        [AllureStep("Click 'Manage' button")]
        public MainWishlistPage ClickManageButton()
        {
            Wait.Until(ElementToBeVisible(_manageButton));
            _manageButton.Click();
            return this;
        }

        [AllureStep("Click 'Tap to Complete' pill")]
        public MainWishlistPage ClickTapToCompleteItemPill()
        {
            Wait.Until(ElementToBeVisible(_tapToCompleteItemPill));
            _tapToCompleteItemPill.Click();
            return this;
        }

        [AllureStep("Click 'Create a Wishlist Account' button")]
        public MainWishlistPage ClickCreateAWishlistAccountButton()
        {
            Wait.Until(ElementToBeVisible(_createAWishlistAccountButton));
            _createAWishlistAccountButton.Click();
            return this;
        }

        [AllureStep("Click '+' placeholder")]
        public MainWishlistPage ClickPlaceholder()
        {
            Wait.Until(ElementToBeVisible(_placeholder));
            _placeholder.Click();
            return this;
        }

        public MainWishlistPage WaitUntilMainWishlistPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeClickable(_howItWorksButton));
                    Wait.Until(ElementToBeVisible(_addAnItemButton));

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