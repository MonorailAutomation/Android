using System;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist
{
    public class EditWishlistItemDetailsPage
    {
        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "buttonIgnore")]
        private IWebElement _doNotAddItemButton;

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _finishButton;

        [FindsBy(How = How.Id, Using = "defaultLayout")]
        private IWebElement _mainScrollView;

        [FindsBy(How = How.Id, Using = "labelPrice")]
        private IWebElement _priceLabel;

        public EditWishlistItemDetailsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        private void WaitUntilEditWishlistItemDetailsPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeClickable(_mainScrollView));
                    Wait.Until(ElementToBeClickable(_doNotAddItemButton));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_finishButton));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }

        public EditWishlistItemDetailsPage ClickPrice()
        {
            WaitUntilEditWishlistItemDetailsPageIsLoaded();

            var secondPointX = _mainScrollView.Size.Width / 2;
            var secondPointY = _mainScrollView.Size.Height - 400;

            Console.WriteLine(secondPointX);
            Console.WriteLine(secondPointY);

            Scroll.ScrollFromToCoordinates(secondPointX, 10, secondPointX, secondPointY);

            _priceLabel.Click();
            return this;
        }

        public EditWishlistItemDetailsPage ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}