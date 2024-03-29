using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist.TransactionPages
{
    public class WishlistFinishAddCashPage
    {
        private const string SuccessHeaderText = "Success!";
        private const string FundsOnTheWayMessageTextPartOne = "Funds are on their way to your";
        private const string FundsOnTheWayMessageTextPartTwo = "connected account!";
        private const string TransferringInformationTextPartOne = "Once completed, this amount will be added to";
        private const string TransferringInformationTextPartTwo = "your Wishlist Account total and will be able to";
        private const string TransferringInformationTextPartThree = "be used for power your purchases.";

        [FindsBy(How = How.Id, Using = "buttonReturn")]
        private IWebElement _finishButton;

        [FindsBy(How = How.Id, Using = "labelTransferringOnTheWay")]
        private IWebElement _fundsOnTheWayMessage;

        [FindsBy(How = How.Id, Using = "labelTransferring")]
        private IWebElement _successHeader;

        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup/android.widget.TextView[4]")]
        private IWebElement _transferringInformation;

        public WishlistFinishAddCashPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Finish' button")]
        public WishlistFinishAddCashPage ClickFinishButton()
        {
            WaitUntilWishlistFinishAddCashPageIsLoaded();
            _finishButton.Click();
            return this;
        }

        private WishlistFinishAddCashPage WaitUntilWishlistFinishAddCashPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_successHeader));
                    Wait.Until(ElementToBeVisible(_fundsOnTheWayMessage));
                    Wait.Until(ElementToBeVisible(_transferringInformation));
                    Wait.Until(ElementToBeVisible(_finishButton));

                    _successHeader.Text.Should().Contain(SuccessHeaderText);
                    _fundsOnTheWayMessage.Text.Should().Contain(FundsOnTheWayMessageTextPartOne);
                    _fundsOnTheWayMessage.Text.Should().Contain(FundsOnTheWayMessageTextPartTwo);
                    _transferringInformation.Text.Should().Contain(TransferringInformationTextPartOne);
                    _transferringInformation.Text.Should().Contain(TransferringInformationTextPartTwo);
                    _transferringInformation.Text.Should().Contain(TransferringInformationTextPartThree);
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