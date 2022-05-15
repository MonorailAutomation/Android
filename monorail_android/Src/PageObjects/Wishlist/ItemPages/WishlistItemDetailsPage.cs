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
    public class WishlistItemDetailsPage
    {
        [FindsBy(How = How.Id, Using = "buttonBack")]
        private IWebElement _backButton;

        [FindsBy(How = How.Id, Using = "buttonEdit")]
        private IWebElement _editButton;

        [FindsBy(How = How.Id, Using = "buttonFund")]
        private IWebElement _fundYourWishlistButton;

        [FindsBy(How = How.Id, Using = "buttonPurchase")]
        private IWebElement _purchaseItemButton;

        [FindsBy(How = How.Id, Using = "buttonBuy")]
        private IWebElement _readyToBuyButton;

        [FindsBy(How = How.Id, Using = "buttonRemove")]
        private IWebElement _removeButton;

        [FindsBy(How = How.Id, Using = "labelTransferDate")]
        private IWebElement _transferringStatusDate;

        [FindsBy(How = How.Id, Using = "labelStatusDescription")]
        private IWebElement _transferringStatusDescription;

        [FindsBy(How = How.Id, Using = "labelItemStatus")]
        private IWebElement _transferringStatusTitle;

        [FindsBy(How = How.Id, Using = "textDescription")]
        private IWebElement _wishlistItemDescription;

        [FindsBy(How = How.Id, Using = "textName")]
        private IWebElement _wishlistItemName;

        [FindsBy(How = How.Id, Using = "textPrice")]
        private IWebElement _wishlistItemPrice;

        public WishlistItemDetailsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public WishlistItemDetailsPage WaitUntilWishlistItemDetailsPageForNotReadyToBuyStateIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeClickable(_editButton));
                    Wait.Until(ElementToBeClickable(_removeButton));
                    Wait.Until(ElementToBeClickable(_fundYourWishlistButton));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }

        public WishlistItemDetailsPage WaitUntilWishlistItemDetailsPageForFundsTransferringStateIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeClickable(_editButton));
                    Wait.Until(ElementToBeClickable(_removeButton));
                    Wait.Until(ElementToBeVisible(_purchaseItemButton));

                    _purchaseItemButton.Enabled.Should().BeFalse();
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }

        [AllureStep("Check transferring status for External transfer")]
        public WishlistItemDetailsPage CheckTransferringStatusForExternalTransfer(string amount)
        {
            const string transferringStatusTitle = "Your funds are on the way!";
            const string transferringStatusDescription = " is on the way to your connected account";
            const string transferringStatusDate = "Transfer started on ";

            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeClickable(_transferringStatusTitle));
                    Wait.Until(ElementToBeClickable(_transferringStatusDescription));
                    Wait.Until(ElementToBeClickable(_transferringStatusDate));

                    _transferringStatusTitle.Text.Should().Be(transferringStatusTitle);
                    _transferringStatusDescription.Text.Should()
                        .Contain("$" + amount).And.Contain(transferringStatusDescription);
                    _transferringStatusDate.Text.Should()
                        .Contain(transferringStatusDate);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }

        public WishlistItemDetailsPage VerifyWishlistItemDetails(string wishlistItemName, string wishlistItemPrice,
            string wishlistItemDescription)
        {
            Wait.Until(ElementToBeVisible(_wishlistItemName));
            Wait.Until(ElementToBeVisible(_wishlistItemPrice));
            Wait.Until(ElementToBeVisible(_wishlistItemDescription));

            _wishlistItemName.Text.Should().Contain(wishlistItemName);
            _wishlistItemPrice.Text.Should().Contain(wishlistItemPrice);
            _wishlistItemDescription.Text.Should().Contain(wishlistItemDescription);
            return this;
        }

        [AllureStep("Click 'Fund your Wishlist' button")]
        public WishlistItemDetailsPage ClickFundYourWishlistButton()
        {
            Wait.Until(ElementToBeVisible(_fundYourWishlistButton));
            _fundYourWishlistButton.Click();
            return this;
        }

        [AllureStep("Click '<' button")]
        public WishlistItemDetailsPage ClickBackButton()
        {
            Wait.Until(ElementToBeVisible(_backButton));
            _backButton.Click();
            return this;
        }

        [AllureStep("Click 'Remove' button")]
        public WishlistItemDetailsPage ClickRemoveButton()
        {
            Wait.Until(ElementToBeVisible(_removeButton));
            _removeButton.Click();
            return this;
        }

        public WishlistItemDetailsPage ClickReadyToBuyButton()
        {
            Wait.Until(ElementToBeVisible(_readyToBuyButton));
            _readyToBuyButton.Click();
            return this;
        }
    }
}