using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

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
            while (_continueButton.Enabled == false) ElementToBeClickable(_continueButton);
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
                    Wait.Until(ElementToBeVisible(_firstNameLabel));
                    Wait.Until(ElementToBeVisible(_firstNameInput));
                    Wait.Until(ElementToBeVisible(_lastNameLabel));
                    Wait.Until(ElementToBeVisible(_lastNameInput));
                    Wait.Until(ElementToBeVisible(_continueButton));

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