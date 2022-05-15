using System;
using FluentAssertions;
using monorail_android.Commons;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Save
{
    public class MainSavePage
    {
        private const string TracksLabelText = "TRACKS";

        private const string SelectYourTracksHeaderText = "Select Your Tracks";

        private const string InformationMessageText =
            "Choose some saving tracks to start with. You can add, remove, or customize these anytime.";

        [FindsBy(How = How.Id, Using = "buttonAddTrack")]
        private IWebElement _addASavingTrackButton;

        [FindsBy(How = How.Id, Using = "buttonGetStarted")]
        private IWebElement _getStartedButton;

        [FindsBy(How = How.Id, Using = "buttonHowItWorks")]
        private IWebElement _howItWorksButton;

        [FindsBy(How = How.Id, Using = "labelDescription")]
        private IWebElement _informationMessage;

        [FindsBy(How = How.Id, Using = "labelSelect")]
        private IWebElement _selectYourTracksHeader;

        [FindsBy(How = How.Id, Using = "mainScrollLayout")]
        private IWebElement _selectYourTracksScrollView;

        [FindsBy(How = How.Id, Using = "labelGoalName")]
        private IWebElement _trackName;

        [FindsBy(How = How.Id, Using = "labelTracks")]
        private IWebElement _tracksLabel;

        public MainSavePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click Track tile: '{0}'")]
        public MainSavePage ClickTrackTile(string trackName)
        {
            WaitUntilSavePageAfterOnboardingIsLoaded();
            var track = Driver.FindElementByXPath("//*[contains(@text, '" + trackName + "')]");
            track.Click();
            return this;
        }

        [AllureStep("Click Track Details of '{0} track")]
        public MainSavePage ClickTrackDetails(string trackName)
        {
            WaitUntilSavePageWithAtLeastOneTrackIsLoaded();
            var track = Driver.FindElementByXPath("//*[contains(@text, '" + trackName + "')]");
            track.Click();
            return this;
        }

        [AllureStep("Click 'Add a Saving Track' button")]
        public MainSavePage ClickAddASavingTrackButton()
        {
            Wait.Until(ElementToBeVisible(_addASavingTrackButton));
            _addASavingTrackButton.Click();
            return this;
        }
        
        [AllureStep("Click 'Get Started' button")]
        public MainSavePage ClickGetStartedButton()
        {
            Wait.Until(ElementToBeVisible(_selectYourTracksScrollView));

            var firstPointX = _selectYourTracksScrollView.Size.Width / 2;
            var firstPointY = _selectYourTracksScrollView.Location.Y + 10;

            var secondPointX = _selectYourTracksScrollView.Size.Width / 2;
            var secondPointY = _selectYourTracksScrollView.Location.Y +
                _selectYourTracksScrollView.Size.Height - 300;

            Scroll.ScrollFromToCoordinates(firstPointX, firstPointY, secondPointX, secondPointY);

            while (_getStartedButton.Enabled == false) Wait.Until(ElementToBeClickable(_getStartedButton));

            _getStartedButton.Click();
            return this;
        }

        public MainSavePage WaitUntilTrackIsDisplayed()
        {
            Wait.Until(ElementToBeVisible(_trackName));
            return this;
        }

        private void WaitUntilSavePageWithAtLeastOneTrackIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_tracksLabel));

                    _tracksLabel.Text.Should().Contain(TracksLabelText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }

        private void WaitUntilSavePageAfterOnboardingIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_selectYourTracksHeader));
                    Wait.Until(ElementToBeVisible(_informationMessage));
                    Wait.Until(ElementToBeClickable(_howItWorksButton));

                    _selectYourTracksHeader.Text.Should().Contain(SelectYourTracksHeaderText);
                    _informationMessage.Text.Should().Contain(InformationMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}