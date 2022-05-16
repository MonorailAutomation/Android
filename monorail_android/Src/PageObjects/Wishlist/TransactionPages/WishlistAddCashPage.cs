using System;
using FluentAssertions;
using monorail_android.Commons;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist.TransactionPages
{
    public class WishlistAddCashPage
    {
        private const string AddCashScreenTitleText = "Add Cash";

        [FindsBy(How = How.Id, Using = "labelScreenTitle")]
        private IWebElement _addCashScreenTitle;

        [FindsBy(How = How.Id, Using = "buttonBack")]
        private IWebElement _backButton;

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        public WishlistAddCashPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click '<' button")]
        public WishlistAddCashPage ClickBackButton()
        {
            Wait.Until(ElementToBeVisible(_backButton));
            _backButton.Click();
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public WishlistAddCashPage ClickContinueButton()
        {
            _continueButton.Click();
            return this;
        }

        [AllureStep("Set amount: '${0}'")]
        public WishlistAddCashPage SetAmount(string amount)
        {
            CustomKeyboard.SendKeys(amount);
            return this;
        }

        public WishlistAddCashPage WaitUntilWishlistAddCashPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_addCashScreenTitle));
                    Wait.Until(ElementToBeVisible(_backButton));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_continueButton));

                    _addCashScreenTitle.Text.Should().Contain(AddCashScreenTitleText);
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