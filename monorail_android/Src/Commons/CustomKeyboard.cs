using OpenQA.Selenium;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.Commons
{
    public class CustomKeyboard
    {
        public static void SendKeys(string value)
        {
            foreach (var c in value)
                Driver.FindElement(By.XPath("//android.widget.TextView[@text='" + c + "']")).Click();
        }

        public static void Clear()
        {
            Driver.FindElement(By.Id("btn_delete")).Click();
        }
    }
}