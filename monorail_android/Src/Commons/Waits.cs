using System;
using OpenQA.Selenium;

namespace monorail_android.Commons
{
    public static class Waits
    {
        public static Func<IWebDriver, IWebElement> ElementToBeClickable(IWebElement element)
        {
            return driver => element is {Displayed: true, Enabled: true} ? element : null;
        }

        public static Func<IWebDriver, IWebElement> ElementToBeVisible(IWebElement element)
        {
            return driver => element is {Displayed: true} ? element : null;
        }

        public static Func<IWebDriver, bool> ElementToBeNotVisible(IWebElement element)
        {
            return driver =>
            {
                try
                {
                    return !element.Displayed;
                }
                catch (NoSuchElementException ex)
                {
                    return true;
                }
                catch (StaleElementReferenceException ex)
                {
                    return true;
                }
            };
        }
    }
}