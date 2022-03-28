using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using static System.TimeSpan;
using static OpenQA.Selenium.Appium.Enums.MobileCapabilityType;

namespace monorail_android.Test
{
    public class FunctionalTesting
    {
        public static AndroidDriver<IWebElement> Driver;
        public static WebDriverWait Wait;

        [SetUp]
        public void BeforeAll()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(PlatformName, "Android");
            capabilities.AddAdditionalCapability(DeviceName, "Pixel 4 API 30");
            capabilities.AddAdditionalCapability("appWaitDuration", 90000);
            capabilities.AddAdditionalCapability("appium:automationName", "UiAutomator2");
            capabilities.AddAdditionalCapability("appWaitPackage", "com.vimvest.android.staging2");
            capabilities.AddAdditionalCapability(NoReset, true);
            capabilities.AddAdditionalCapability(App,
                "/Users/hannakuczara/Vimvest/AndroidClient/app/build/outputs/apk/dev/debug/app-dev-debug.apk");

            Driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), capabilities,
                FromSeconds(600));
            Driver.Manage().Timeouts().ImplicitWait = FromSeconds(45);
            Wait = new WebDriverWait(Driver, FromSeconds(30));
        }

        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
}