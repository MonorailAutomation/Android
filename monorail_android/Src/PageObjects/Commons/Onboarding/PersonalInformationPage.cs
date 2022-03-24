using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace monorail_android.PageObjects.Commons.Onboarding
{
    public class PersonalInformationPage
    {
        private const string PersonalInformationHeaderText = "Personal Information";

        private const string InformationMessageText =
            "In order to finish setting up your account, we need more information about you.";

        private const string TimeMessageText = "This will take about 1 minute.";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _getStartedButton;

        [FindsBy(How = How.Id, Using = "labelIntroText")]
        private IWebElement _informationMessage;

        [FindsBy(How = How.Id, Using = "labelTitle")]
        private IWebElement _personalInformationHeader;

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        [FindsBy(How = How.Id, Using = "labelTimeToComplete")]
        private IWebElement _timeMessage;

        public PersonalInformationPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public PersonalInformationPage ClickGetStartedButton()
        {
            WaitUntilPersonalInformationPageIsLoaded();
            _getStartedButton.Click();
            return this;
        }

        private void WaitUntilPersonalInformationPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Waits.ElementToBeNotVisible(_progressIndicator);
                    Waits.ElementToBeVisible(_personalInformationHeader);
                    Waits.ElementToBeVisible(_informationMessage);
                    Waits.ElementToBeVisible(_timeMessage);
                    Waits.ElementToBeClickable(_getStartedButton);

                    _personalInformationHeader.Text.Should().Contain(PersonalInformationHeaderText);
                    _informationMessage.Text.Should().Contain(InformationMessageText);
                    _timeMessage.Text.Should().Contain(TimeMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}