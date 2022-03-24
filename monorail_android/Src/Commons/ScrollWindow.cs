using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.Commons
{
    public static class Scroll
    {
        public static void ScrollFromToElement(IWebElement element1, IWebElement element2)
        {
            var ta = new TouchAction(Driver);
            ta.Press(element2).Wait(1000).MoveTo(element1).Release().Perform();
        }

        public static void ScrollFromToCoordinates(int firstPointX, int firstPointY, int secondPointX, int secondPointY)
        {
            var ta = new TouchAction(Driver);
            ta.Press(secondPointX, secondPointY).Wait(1000).MoveTo(firstPointX, firstPointY).Release().Perform();
        }
    }
}