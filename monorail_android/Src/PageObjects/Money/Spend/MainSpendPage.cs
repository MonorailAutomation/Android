using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Money.Spend
{
    public class MainSpendPage
    {
        private const string RejectedAccountStatusTitle = "Account Rejected";
        private const string RejectedAccountStatusMessagePartOne = "Your account application was rejected.";
        private const string RejectedAccountStatusMessagePartTwo = "Please reach out to the team for assistance.";

        private const string RejectedAccountStatusMessagePartThree =
            "While in this state, you will not be able manage your Monorail account.";

        private const string ManualReviewAccountStatusTitle = "We need more info.";

        private const string ManualReviewAccountStatusMessagePartOne =
            "In order to finish setting up your account, reach out to Customer Support.";

        private const string ManualReviewAccountStatusMessagePartTwo =
            "While in this state, you will not be able manage your Monorail account.";

        [FindsBy(How = How.Id, Using = "cardSegmentSubtitle")]
        private IWebElement _accountStatusCardMessage;

        [FindsBy(How = How.Id, Using = "cardSegmentTitle")]
        private IWebElement _accountStatusCardTitle;

        [FindsBy(How = How.Id, Using = "chatWithTheTeam")]
        private IWebElement _chatWithTheTeamButton;

        [FindsBy(How = How.Id, Using = "buttonWithdraw")]
        private IWebElement _cashOutButton;

        public MainSpendPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MainSpendPage ClickCashOutButton()
        {
            Wait.Until(ElementToBeVisible(_cashOutButton));
            _cashOutButton.Click();
            return this;
        }

        public void WaitUntilRejectedAccountStatusIsDisplayed()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_accountStatusCardTitle));
                    Wait.Until(ElementToBeVisible(_accountStatusCardMessage));
                    Wait.Until(ElementToBeVisible(_chatWithTheTeamButton));

                    _accountStatusCardTitle.Text.Should().Contain(RejectedAccountStatusTitle);
                    _accountStatusCardMessage.Text.Should().Contain(RejectedAccountStatusMessagePartOne);
                    _accountStatusCardMessage.Text.Should().Contain(RejectedAccountStatusMessagePartTwo);
                    _accountStatusCardMessage.Text.Should().Contain(RejectedAccountStatusMessagePartThree);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }

        public void WaitUntilManualReviewAccountStatusIsDisplayed()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_accountStatusCardTitle));
                    Wait.Until(ElementToBeVisible(_accountStatusCardMessage));
                    Wait.Until(ElementToBeVisible(_chatWithTheTeamButton));

                    _accountStatusCardTitle.Text.Should().Contain(ManualReviewAccountStatusTitle);
                    _accountStatusCardMessage.Text.Should().Contain(ManualReviewAccountStatusMessagePartOne);
                    _accountStatusCardMessage.Text.Should().Contain(ManualReviewAccountStatusMessagePartTwo);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}