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
    public class WishlistManagePage
    {
        private const string HeaderText = "Wishlist Account";

        [FindsBy(How = How.Id, Using = "buttonBack")]
        private IWebElement _backButton;

        [FindsBy(How = How.Id, Using = "buttonAddCash")]
        private IWebElement _addCashButton;

        [FindsBy(How = How.Id, Using = "buttonCashOut")]
        private IWebElement _cashOutButton;

        [FindsBy(How = How.Id, Using = "labelTitle")]
        private IWebElement _header;

        [FindsBy(How = How.Id, Using = "labelEnableDepositSchedule")]
        private IWebElement _scheduledDepositsLabel;

        public WishlistManagePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Add Cash' button")]
        public WishlistManagePage ClickAddAnCashButton()
        {
            Wait.Until(ElementToBeVisible(_addCashButton));
            _addCashButton.Click();
            return this;
        }

        [AllureStep("Click '<' button")]
        public WishlistManagePage ClickBackButton()
        {
            Wait.Until(ElementToBeVisible(_backButton));
            _backButton.Click();
            return this;
        }

        public WishlistManagePage WaitUntilWishlistManagePageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeClickable(_addCashButton));
                    Wait.Until(ElementToBeVisible(_header));
                    Wait.Until(ElementToBeVisible(_scheduledDepositsLabel));

                    _header.Text.Should().Contain(HeaderText);
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