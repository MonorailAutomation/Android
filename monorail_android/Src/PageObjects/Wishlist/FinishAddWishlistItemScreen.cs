using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist
{
    public class FinishAddWishlistItemScreen
    {
        [FindsBy(How = How.Id, Using = "buttonClose")]
        private IWebElement _closeButton;

        [FindsBy(How = How.Id, Using = "buttonOpenAccount")]
        private IWebElement _openYourWishlistAccountButton;

        public FinishAddWishlistItemScreen(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public FinishAddWishlistItemScreen ClickCloseButton()
        {
            WaitUntilFinishAddWishlistItemScreenIsLoaded();
            _closeButton.Click();
            return this;
        }

        private void WaitUntilFinishAddWishlistItemScreenIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_openYourWishlistAccountButton));
                    Wait.Until(ElementToBeVisible(_closeButton));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}