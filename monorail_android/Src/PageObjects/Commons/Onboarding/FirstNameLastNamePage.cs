using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace monorail_android.PageObjects.Commons.Onboarding
{
    public class FirstNameLastNamePage
    {
        private const string FirstNameLabelText = "Your First Name";
        private const string LastNameLabelText = "Your Last Name";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "editFirstName")]
        private IWebElement _firstNameInput;

        [FindsBy(How = How.Id, Using = "labelFirstName")]
        private IWebElement _firstNameLabel;

        [FindsBy(How = How.Id, Using = "editLastName")]
        private IWebElement _lastNameInput;

        [FindsBy(How = How.Id, Using = "labelLastName")]
        private IWebElement _lastNameLabel;

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        public FirstNameLastNamePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public FirstNameLastNamePage PassFirstAndLastName(string firstName, string lastName)
        {
            WaitUntilFirstNameLastNamePageIsLoaded();
            _firstNameInput.SendKeys(firstName);
            _lastNameInput.SendKeys(lastName);
            return this;
        }

        public FirstNameLastNamePage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) Waits.ElementToBeClickable(_continueButton);
            _continueButton.Click();
            return this;
        }

        private void WaitUntilFirstNameLastNamePageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Waits.ElementToBeNotVisible(_progressIndicator);
                    Waits.ElementToBeVisible(_firstNameLabel);
                    Waits.ElementToBeVisible(_firstNameInput);
                    Waits.ElementToBeVisible(_lastNameLabel);
                    Waits.ElementToBeVisible(_lastNameInput);
                    Waits.ElementToBeClickable(_continueButton);

                    _firstNameLabel.Text.Should().Contain(FirstNameLabelText);
                    _lastNameLabel.Text.Should().Contain(LastNameLabelText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}