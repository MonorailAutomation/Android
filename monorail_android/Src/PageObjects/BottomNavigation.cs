using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects
{
    public class BottomNavigation
    {
        [FindsBy(How = How.XPath,
            Using = "//*[contains(@resource-id, 'cardNavigationContents')]/android.widget.ImageView[3]")]
        private IWebElement _investNavButton;

        [FindsBy(How = How.XPath,
            Using = "//*[contains(@resource-id, 'cardNavigationContents')]/android.widget.ImageView[2]")]
        private IWebElement _moneyNavButton;

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        [FindsBy(How = How.XPath,
            Using = "//*[contains(@resource-id, 'cardNavigationContents')]/android.widget.ImageView[1]")]
        private IWebElement _wishlistNavButton;

        public BottomNavigation(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public BottomNavigation ClickWishlistNavButton()
        {
            Wait.Until(ElementToBeClickable(_moneyNavButton));
            _wishlistNavButton.Click();
            return this;
        }

        public BottomNavigation ClickMoneyNavButton()
        {
            Wait.Until(ElementToBeClickable(_moneyNavButton));
            _moneyNavButton.Click();
            return this;
        }

        public BottomNavigation ClickInvestNavButton()
        {
            Wait.Until(ElementToBeClickable(_investNavButton));
            _investNavButton.Click();
            return this;
        }
    }
}