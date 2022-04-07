namespace monorail_android.Model.ConfigurationModel
{
    public class AppiumConfiguration
    {
        public int WaitDuration { get; set; }
        public int CommandTimeout { get; set; }
        public string AutomationName { get; set; }
        public bool NoResetFlag { get; set; }
    }
}