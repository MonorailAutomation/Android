using static monorail_android.DataGenerators.DateGenerator;
using static monorail_android.DataGenerators.NumberGenerator;

namespace monorail_android.DataGenerators
{
    public static class StringGenerator
    {
        public static string GenerateStringWithNumber()
        {
            return GetCurrentDateFormatted() + " " + GenerateRandomDigits(2);
        }
    }
}