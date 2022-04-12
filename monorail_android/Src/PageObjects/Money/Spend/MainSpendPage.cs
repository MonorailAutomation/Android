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

        [FindsBy(How = How.Id, Using = "cardSegmentSubtitle")]
        private IWebElement _accountStatusCardMessage;

        [FindsBy(How = How.Id, Using = "cardSegmentTitle")]
        private IWebElement _accountStatusCardTitle;

        [FindsBy(How = How.Id, Using = "chatWithTheTeam")]
        private IWebElement _chatWithTheTeamButton;

        public MainSpendPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
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
    }
}