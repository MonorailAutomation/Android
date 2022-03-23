using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace monorail_android.PageObjects.MainMenu
{
    public class LogOutBottomUp
    {
        [FindsBy(How = How.Id, Using = "buttonConfirm")]
        private IWebElement _yesButton;

        public LogOutBottomUp(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public LogOutBottomUp ClickYesButton()
        {
            _yesButton.Click();
            return this;
        }
    }
}