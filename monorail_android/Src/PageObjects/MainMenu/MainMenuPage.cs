using System;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace monorail_android.PageObjects.MainMenu
{
    public class MainMenuPage
    {
        [FindsBy(How = How.Id, Using = "lbl_ask_question")]
        private IWebElement _askQuestionNavItem;

        [FindsBy(How = How.Id, Using = "buttonGiving")]
        private IWebElement _givingNavItem;

        [FindsBy(How = How.Id, Using = "lbl_logout")]
        private IWebElement _logOutNavItem;

        [FindsBy(How = How.Id, Using = "lbl_more_info")]
        private IWebElement _moreInfoNavItem;

        [FindsBy(How = How.Id, Using = "lbl_my_connected_account")]
        private IWebElement _myConnectedAccountNavItem;

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        [FindsBy(How = How.Id, Using = "toggleImage")]
        private IWebElement _sideMenu;

        public MainMenuPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MainMenuPage ClickLogOut()
        {
            WaitUntilMainMenuIsLoaded();
            Scroll.ScrollFromToElement(_givingNavItem, _moreInfoNavItem);
            _logOutNavItem.Click();
            return this;
        }

        public MainMenuPage ClickMyConnectedAccount()
        {
            WaitUntilMainMenuIsLoaded();
            _myConnectedAccountNavItem.Click();
            return this;
        }

        public MainMenuPage ClickSideMenu()
        {
            Waits.ElementToBeNotVisible(_progressIndicator);
            Waits.ElementToBeClickable(_sideMenu);
            _sideMenu.Click();
            return this;
        }

        private void WaitUntilMainMenuIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Waits.ElementToBeClickable(_sideMenu);
                    Waits.ElementToBeVisible(_givingNavItem);
                    Waits.ElementToBeVisible(_moreInfoNavItem);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}