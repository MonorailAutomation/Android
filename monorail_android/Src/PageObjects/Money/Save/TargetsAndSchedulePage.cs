using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Save
{
    public class TargetsAndSchedulePage
    {
        private const string TargetsAndSchedulePageTitleText = "Targets & Schedule";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "buttonDaily")]
        private IWebElement _dailyFrequencyButton;

        [FindsBy(How = How.Id, Using = "clickOverlayFrequencyDay")]
        private IWebElement _dayOfWeekDayOfMonthField;

        [FindsBy(How = How.Id, Using = "clickOverlayDepositAmount")]
        private IWebElement _depositAmountField;

        [FindsBy(How = How.Id, Using = "switchEnableDepositSchedule")]
        private IWebElement _enableScheduledDepositSwitch;

        [FindsBy(How = How.Id, Using = "buttonMonthly")]
        private IWebElement _monthlyFrequencyButton;

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _pageTitle;

        [FindsBy(How = How.Id, Using = "fieldTargetAmount")]
        private IWebElement _targetAmountField;

        [FindsBy(How = How.Id, Using = "fieldTargetDate")]
        private IWebElement _targetDateField;

        [FindsBy(How = How.Id, Using = "buttonWeekly")]
        private IWebElement _weeklyFrequencyButton;


        public TargetsAndSchedulePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Target Date' field")]
        public TargetsAndSchedulePage ClickTargetDateField()
        {
            WaitUntilTargetsAndSchedulePageIsLoaded();
            _targetDateField.Click();
            return this;
        }

        [AllureStep("Disable Scheduled Deposit")]
        public TargetsAndSchedulePage DisableScheduledDeposit()
        {
            WaitUntilTargetsAndSchedulePageIsLoaded();
            _enableScheduledDepositSwitch.Click();
            return this;
        }

        [AllureStep("Click 'Target Amount' field")]
        public TargetsAndSchedulePage ClickTargetAmountField()
        {
            WaitUntilTargetsAndSchedulePageIsLoaded();
            _targetAmountField.Click();
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public TargetsAndSchedulePage ClickContinueButton()
        {
            _continueButton.Click();
            return this;
        }

        private void WaitUntilTargetsAndSchedulePageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pageTitle));
                    Wait.Until(ElementToBeVisible(_targetAmountField));
                    Wait.Until(ElementToBeVisible(_targetDateField));
                    Wait.Until(ElementToBeVisible(_depositAmountField));
                    Wait.Until(ElementToBeVisible(_dailyFrequencyButton));
                    Wait.Until(ElementToBeVisible(_weeklyFrequencyButton));
                    Wait.Until(ElementToBeVisible(_monthlyFrequencyButton));
                    Wait.Until(ElementToBeVisible(_dayOfWeekDayOfMonthField));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_continueButton));

                    _pageTitle.Text.Should().Contain(TargetsAndSchedulePageTitleText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}