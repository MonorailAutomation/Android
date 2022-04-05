using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Save
{
    public class EditTrackName
    {
        private const string NameScreenHeaderText = "Name";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "textField")]
        private IWebElement _nameInput;

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _nameScreenHeader;

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _saveButton;

        public EditTrackName(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public EditTrackName ClickSaveButton()
        {
            WaitUntilEditTrackNamePageIsLoaded();
            _saveButton.Click();
            return this;
        }

        public EditTrackName SetTrackName(string trackName)
        {
            WaitUntilEditTrackNamePageIsLoaded();
            _nameInput.Clear();
            _nameInput.SendKeys(trackName);
            return this;
        }

        private void WaitUntilEditTrackNamePageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_nameScreenHeader));
                    Wait.Until(ElementToBeVisible(_nameInput));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_saveButton));

                    _nameScreenHeader.Text.Should().Be(NameScreenHeaderText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}