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
    public class CompleteYourItemPricePage
    {
        private const string PriceInputPlaceholderText = "$0.00";

        private const string PageHeaderText = "Complete your Item info";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "labelCheckProductName")]
        private IWebElement _checkProductPriceButton;

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _pageHeader;

        [FindsBy(How = How.Id, Using = "editLastName")]
        private IWebElement _wishlistItemPriceInput;

        public CompleteYourItemPricePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public CompleteYourItemPricePage ClickContinueButton()
        {
            Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }

        [AllureStep("Set Wishlist Item Price: '{0}'")]
        public CompleteYourItemPricePage SetWishlistItemPrice(string wishlistItemPrice)
        {
            WaitUntilCompleteYourItemPricePageIsLoaded();
            Wait.Until(ElementToBeVisible(_wishlistItemPriceInput));
            _wishlistItemPriceInput.SendKeys(wishlistItemPrice);
            return this;
        }

        private void WaitUntilCompleteYourItemPricePageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pageHeader));
                    Wait.Until(ElementToBeVisible(_wishlistItemPriceInput));
                    Wait.Until(ElementToBeVisible(_checkProductPriceButton));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_continueButton));

                    _pageHeader.Text.Should().Contain(PageHeaderText);
                    _wishlistItemPriceInput.Text.Should().Contain(PriceInputPlaceholderText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}