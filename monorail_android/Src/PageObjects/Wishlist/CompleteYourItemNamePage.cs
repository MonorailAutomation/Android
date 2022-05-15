using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist
{
    public class CompleteYourItemNamePage
    {
        private const string NameInputPlaceholderText = "Insert name...";

        private const string PageHeaderText = "Complete your Item info";

        private const string TipMessageTextPartOne = "Tip: Copy and paste the product name from the website";
        private const string TipMessageTextPartTwo = "for best results.";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "labelCheckProductName")]
        private IWebElement _checkProductNameButton;

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _pageHeader;

        [FindsBy(How = How.Id, Using = "labelTip")]
        private IWebElement _tipMessage;


        [FindsBy(How = How.Id, Using = "editLastName")]
        private IWebElement _wishlistItemNameInput;

        public CompleteYourItemNamePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public CompleteYourItemNamePage ClickContinueButton()
        {
            Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }

        [AllureStep("Set Wishlist Item Name: '{0}'")]
        public CompleteYourItemNamePage SetWishlistItemName(string wishlistItemName)
        {
            WaitUntilCompleteYourItemNamePageIsLoaded();
            Wait.Until(ElementToBeVisible(_wishlistItemNameInput));
            _wishlistItemNameInput.SendKeys(wishlistItemName);
            return this;
        }

        private void WaitUntilCompleteYourItemNamePageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pageHeader));
                    Wait.Until(ElementToBeVisible(_wishlistItemNameInput));
                    Wait.Until(ElementToBeVisible(_checkProductNameButton));
                    Wait.Until(ElementToBeVisible(_tipMessage));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_continueButton));

                    _pageHeader.Text.Should().Contain(PageHeaderText);
                    _wishlistItemNameInput.Text.Should().Contain(NameInputPlaceholderText);
                    _tipMessage.Text.Should().Contain(TipMessageTextPartOne);
                    _tipMessage.Text.Should().Contain(TipMessageTextPartTwo);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}