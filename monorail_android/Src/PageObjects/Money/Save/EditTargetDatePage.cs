using System;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Save
{
    public class EditTargetDatePage
    {
        private const string TargetsAndSchedulePageTitleText = "Targets & Schedule";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "noTargetDateForThisGoal")]
        private IWebElement _noTargetDateForThisGoalButton;

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _saveButton;

        public EditTargetDatePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Save' button")]
        public EditTargetDatePage ClickSaveButton()
        {
            WaitUntilEditTargetPageIsLoaded();
            _saveButton.Click();
            return this;
        }

        private void WaitUntilEditTargetPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_noTargetDateForThisGoalButton));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_saveButton));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}