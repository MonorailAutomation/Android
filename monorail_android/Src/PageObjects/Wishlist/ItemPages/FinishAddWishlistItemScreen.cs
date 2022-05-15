using System;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist.ItemPages
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

        [AllureStep("Click 'Close' button")]
        public FinishAddWishlistItemScreen ClickCloseButton()
        {
            _closeButton.Click();
            return this;
        }

        public FinishAddWishlistItemScreen WaitUntilFinishAddWishlistItemScreenWhenUserHasAccountIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_closeButton));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }

        public FinishAddWishlistItemScreen WaitUntilFinishAddWishlistItemScreenWhenUserDoesntHaveAccountIsLoaded()
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

            return this;
        }
    }
}