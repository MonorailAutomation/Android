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
        private const string EmptyScreenMessageHeaderText = "You’ve got the power.";

        private const string EmptyScreenMessageText =
            "All the things you want. All in one place. Powered by you & your bank account.";

        [FindsBy(How = How.Id, Using = "buttonAddItem")]
        private IWebElement _addAnItemButton;

        [FindsBy(How = How.Id, Using = "labelTextEmpty")]
        private IWebElement _emptyScreenMessage;

        [FindsBy(How = How.Id, Using = "labelTitleEmpty")]
        private IWebElement _emptyScreenMessageHeader;

        [FindsBy(How = How.Id, Using = "buttonHowItWorks")]
        private IWebElement _howItWorksButton;

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        public MainWishlistPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MainWishlistPage WaitUntilEmptyMainWishlistPageIsLoaded()
        {
            Wait.Until(ElementToBeNotVisible(_progressIndicator));
            Wait.Until(ElementToBeClickable(_howItWorksButton));
            Wait.Until(ElementToBeClickable(_addAnItemButton));
            Wait.Until(ElementToBeVisible(_emptyScreenMessageHeader));
            Wait.Until(ElementToBeVisible(_emptyScreenMessage));

            _emptyScreenMessageHeader.Text.Should().Contain(EmptyScreenMessageHeaderText);
            _emptyScreenMessage.Text.Should().Contain(EmptyScreenMessageText);
            return this;
        }

        public MainWishlistPage ClickWishlistItem(string wishlistItemName)
        {
            var wishlistItemSelector = "//*[contains(@text, '" + wishlistItemName + "')]";
            var wishlistItemElement = Driver.FindElementByXPath(wishlistItemSelector);

            Wait.Until(ElementToBeNotVisible(_progressIndicator));
            Wait.Until(ElementToBeVisible(wishlistItemElement));
            wishlistItemElement.Click();
            return this;
        }
    }
}