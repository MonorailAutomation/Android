using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

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
            Waits.ElementToBeNotVisible(_progressIndicator);
            Waits.ElementToBeClickable(_howItWorksButton);
            Waits.ElementToBeClickable(_addAnItemButton);
            Waits.ElementToBeVisible(_emptyScreenMessageHeader);
            Waits.ElementToBeVisible(_emptyScreenMessage);

            _emptyScreenMessageHeader.Text.Should().Contain(EmptyScreenMessageHeaderText);
            _emptyScreenMessage.Text.Should().Contain(EmptyScreenMessageText);
            return this;
        }
    }
}