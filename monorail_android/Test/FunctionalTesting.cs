using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using monorail_android.Model.ConfigurationModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using static System.TimeSpan;
using static Allure.Commons.AllureConstants;
using static monorail_android.Configuration;

namespace monorail_android.Test
{
    public class FunctionalTesting
    {
        public static string MonorailTestEnvironment;
        public static AndroidDriver<IWebElement> Driver;
        public static WebDriverWait Wait;

        [SetUp]
        public void BeforeAll()
        {
            BuildAllureConfig();
            
            var configuration = new ConfigurationBuilder().BuildAppSettings();

            var appConfiguration = configuration.GetSection("AppConfiguration").Get<AppConfiguration>();
            var appiumConfiguration = configuration.GetSection("AppiumConfiguration").Get<AppiumConfiguration>();
            var emulatorConfiguration = configuration.GetSection("EmulatorConfiguration").Get<EmulatorConfiguration>();
            var environmentConfiguration =
                configuration.GetSection("EnvironmentConfiguration").Get<EnvironmentConfiguration>();
            var waitsConfiguration = configuration.GetSection("WaitsConfiguration").Get<WaitsConfiguration>();

            var capabilities = new AppiumOptions();

            capabilities.AddAdditionalCapability("platformName", emulatorConfiguration.PlatformName);
            capabilities.AddAdditionalCapability("noReset", appiumConfiguration.NoResetFlag);
            capabilities.AddAdditionalCapability("appium:deviceName", emulatorConfiguration.DeviceName);
            capabilities.AddAdditionalCapability("appium:automationName", appiumConfiguration.AutomationName);
            capabilities.AddAdditionalCapability("appWaitDuration", appiumConfiguration.WaitDuration);
            capabilities.AddAdditionalCapability("appPackage", appConfiguration.Package);
            capabilities.AddAdditionalCapability("appActivity", appConfiguration.Activity);

            Driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities,
                FromSeconds(appiumConfiguration.CommandTimeout));
            Driver.Manage().Timeouts().ImplicitWait = FromSeconds(waitsConfiguration.ImplicitWaitDuration);
            Wait = new WebDriverWait(Driver, FromSeconds(waitsConfiguration.ExplicitWaitDuration));

            MonorailTestEnvironment = environmentConfiguration.TestEnvironment;
        }

        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
}