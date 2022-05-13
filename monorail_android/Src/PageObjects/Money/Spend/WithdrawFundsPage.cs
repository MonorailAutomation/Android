using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Spend
{
    public class WithdrawFundsPage
    {
        private const string WithdrawFundsPageTitleText = "Withdraw Funds";
        private const string ChooseAWithdrawalAmountMessageText = "Choose a withdrawal amount";

        [FindsBy(How = How.Id, Using = "labelChoose")]
        private IWebElement _chooseAWithdrawalAmountMessage;

        [FindsBy(How = How.Id, Using = "buttonConfirm")]
        private IWebElement _confirmButton;

        [FindsBy(How = How.Id, Using = "labelScreenTitle")]
        private IWebElement _withdrawFundsPageTitle;

        public WithdrawFundsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public WithdrawFundsPage ClickConfirmButton()
        {
            while (_confirmButton.Enabled == false) ElementToBeClickable(_confirmButton);
            _confirmButton.Click();
            return this;
        }

        public WithdrawFundsPage SetAmount(string amount)
        {
            WaitUntilWithdrawFunsPageIsLoaded();
            CustomKeyboard.SendKeys(amount);
            return this;
        }

        private void WaitUntilWithdrawFunsPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_withdrawFundsPageTitle));
                    Wait.Until(ElementToBeVisible(_chooseAWithdrawalAmountMessage));
                    Wait.Until(ElementToBeVisible(_confirmButton));

                    _withdrawFundsPageTitle.Text.Should().Contain(WithdrawFundsPageTitleText);
                    _chooseAWithdrawalAmountMessage.Text.Should().Contain(ChooseAWithdrawalAmountMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}