using NUnit.Allure.Attributes;
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

        [FindsBy(How = How.XPath,
            Using = "//*[contains(@resource-id, 'cardNavigationContents')]/android.widget.ImageView[1]")]
        private IWebElement _wishlistNavButton;

        public BottomNavigation(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Wishlist' button on navigation")]
        public BottomNavigation ClickWishlistNavButton()
        {
            Wait.Until(ElementToBeVisible(_wishlistNavButton));
            _wishlistNavButton.Click();
            return this;
        }

        [AllureStep("Click 'Money' button on navigation")]
        public BottomNavigation ClickMoneyNavButton()
        {
            Wait.Until(ElementToBeVisible(_moneyNavButton));
            _moneyNavButton.Click();
            return this;
        }

        [AllureStep("Click 'Invest' button on navigation")]
        public BottomNavigation ClickInvestNavButton()
        {
            Wait.Until(ElementToBeVisible(_investNavButton));
            _investNavButton.Click();
            return this;
        }
    }
}