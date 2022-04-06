using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist
{
    public class WishlistItemDetailsPage
    {
        [FindsBy(How = How.Id, Using = "buttonBack")]
        private IWebElement _backButton;

        [FindsBy(How = How.Id, Using = "buttonEdit")]
        private IWebElement _editButton;

        [FindsBy(How = How.Id, Using = "buttonFund")]
        private IWebElement _fundYourWishlistButton;

        [FindsBy(How = How.Id, Using = "buttonRemove")]
        private IWebElement _removeButton;

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

        public WishlistItemDetailsPage ClickFundYourWishlistButton()
        {
            Wait.Until(ElementToBeVisible(_fundYourWishlistButton));
            _fundYourWishlistButton.Click();
            return this;
        }

        public WishlistItemDetailsPage ClickBackButton()
        {
            Wait.Until(ElementToBeVisible(_backButton));
            _backButton.Click();
            return this;
        }

        public WishlistItemDetailsPage ClickRemoveButton()
        {
            Wait.Until(ElementToBeVisible(_removeButton));
            _removeButton.Click();
            return this;
        }
    }
}