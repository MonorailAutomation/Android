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
    public class FinishAddSavingTrackPage
    {
        private const string TrackIsBeingAddedMessageTextPartOne = "Your new saving track is";
        private const string TrackIsBeingAddedMessageTextPartTwo = "being added now.";
        private const string NiceHeaderText = "Nice!";

        [FindsBy(How = How.Id, Using = "buttonClose")]
        private IWebElement _finishButton;

        [FindsBy(How = How.Id, Using = "labelNice")]
        private IWebElement _niceHeader;

        [FindsBy(How = How.Id, Using = "goalImage")]
        private IWebElement _trackImage;

        [FindsBy(How = How.Id, Using = "labelSubtitle")]
        private IWebElement _trackIsBeingAddedMessage;

        public FinishAddSavingTrackPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public FinishAddSavingTrackPage ClickContinueButton()
        {
            WaitUntilFinishAddSavingTrackPageIsLoaded();
            _finishButton.Click();
            return this;
        }

        private void WaitUntilFinishAddSavingTrackPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_niceHeader));
                    Wait.Until(ElementToBeVisible(_trackIsBeingAddedMessage));
                    Wait.Until(ElementToBeVisible(_trackImage));
                    Wait.Until(ElementToBeVisible(_finishButton));

                    _niceHeader.Text.Should().Contain(NiceHeaderText);
                    _trackIsBeingAddedMessage.Text.Should().Contain(TrackIsBeingAddedMessageTextPartOne);
                    _trackIsBeingAddedMessage.Text.Should().Contain(TrackIsBeingAddedMessageTextPartTwo);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}