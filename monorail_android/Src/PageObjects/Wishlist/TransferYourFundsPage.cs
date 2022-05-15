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
    public class TransferYourFundsPage
    {
        private const string TransferYourFundsPageHeaderText = "Transfer Your Funds";
        private const string PurchaseItemMessageTextPartOne = "In order to purchase your item, you need to move";
        private const string PurchaseItemMessageTextPartTwo = "your funds to a bank account.";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "externalAccountCheckbox")]
        private IWebElement _externalBankAccountOption;

        [FindsBy(How = How.Id, Using = "monorailCardCheckbox")]
        private IWebElement _monorailSpendingCardOption;

        [FindsBy(How = How.Id, Using = "disclaimerLabel")]
        private IWebElement _purchaseItemMessage;

        [FindsBy(How = How.Id, Using = "labelTitle")]
        private IWebElement _transferYourFundsPageHeader;

        public TransferYourFundsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public TransferYourFundsPage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }

        [AllureStep("Click 'External Bank Account' option")]
        public TransferYourFundsPage ClickExternalBankAccountOption()
        {
            WaitUntilTransferYourFundsPageIsLoaded();
            _externalBankAccountOption.Click();
            return this;
        }

        private void WaitUntilTransferYourFundsPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_transferYourFundsPageHeader));
                    Wait.Until(ElementToBeVisible(_purchaseItemMessage));
                    Wait.Until(ElementToBeVisible(_monorailSpendingCardOption));
                    Wait.Until(ElementToBeVisible(_externalBankAccountOption));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_continueButton));

                    _transferYourFundsPageHeader.Text.Should().Contain(TransferYourFundsPageHeaderText);
                    _purchaseItemMessage.Text.Should().Contain(PurchaseItemMessageTextPartOne);
                    _purchaseItemMessage.Text.Should().Contain(PurchaseItemMessageTextPartTwo);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}