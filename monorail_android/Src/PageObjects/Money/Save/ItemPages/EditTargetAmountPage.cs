using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Save.ItemPages
{
    public class EditTargetAmountPage
    {
        private const string TargetAmountTitleText = "Target Amount";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "noTargetAmountLabel")]
        private IWebElement _noTargetAmountForThisGoalButton;

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _saveButton;

        [FindsBy(How = How.Id, Using = "userEditedAmount")]
        private IWebElement _targetAmountInput;

        [FindsBy(How = How.Id, Using = "titleTargetAmount")]
        private IWebElement _targetAmountTitle;

        public EditTargetAmountPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Save' button")]
        public EditTargetAmountPage ClickSaveButton()
        {
            WaitUntilEditTargetAmountPageIsLoaded();
            _saveButton.Click();
            return this;
        }

        [AllureStep("Click 'No Target Amount for this Goal' button")]
        public EditTargetAmountPage ClickNoTargetAmountForThisGoalButton()
        {
            WaitUntilEditTargetAmountPageIsLoaded();
            _noTargetAmountForThisGoalButton.Click();
            return this;
        }

        private void WaitUntilEditTargetAmountPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_targetAmountTitle));
                    Wait.Until(ElementToBeVisible(_targetAmountInput));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_saveButton));

                    _targetAmountTitle.Text.Should().Be(TargetAmountTitleText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}