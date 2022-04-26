using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects
{
    public class BottomUpModal
    {
        [FindsBy(How = How.Id,
            Using = "buttonDismiss")]
        private IWebElement _dismissButton;

        public BottomUpModal(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public BottomUpModal ClickDismissButton()
        {
            Wait.Until(ElementToBeVisible(_dismissButton));
            _dismissButton.Click();
            return this;
        }
    }
}