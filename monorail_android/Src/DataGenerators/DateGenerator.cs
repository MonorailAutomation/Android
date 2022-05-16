using static System.DateTime;

namespace monorail_android.DataGenerators
{
    public static class DateGenerator
    {
        public static string GetCurrentDatePlain()
        {
            return Now.ToString("ddMMyy");
        }

        public static string GetCurrentDateFormatted()
        {
            return Now.ToString("dd/MM/yyyy");
        }
    }
}