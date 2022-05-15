using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using static Allure.Commons.AllureConstants;

namespace monorail_android
{
    public static class Configuration
    {
        private const string ConfigFolder = "Config";
        
        public static IConfigurationRoot BuildAppSettings(this IConfigurationBuilder configBuilder)
        {
            const string configFolder = "Config";
            const string appSettingsFile = "appsettings.json";

            var projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var appSettingFilePath = Path.Combine(projectPath, configFolder, appSettingsFile);

            var configuration = configBuilder
                .AddJsonFile(appSettingFilePath, false, true)
                .Build();

            return configuration;
        }
        
        public static void BuildAllureConfig()
        {
            Environment.SetEnvironmentVariable(ALLURE_CONFIG_ENV_VARIABLE,
                Path.Combine(GetProjectPath(), ConfigFolder, CONFIG_FILENAME));
        }

        private static string GetProjectPath()
        {
            return Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        }
    }
}