using System;

namespace monorail_android.Commons
{
    public static class NumberGenerator
    {
        public static string GenerateRandomNumber()
        {
            return new Random().Next(100, 999).ToString();
        }

        public static string GenerateRandom4Digits()
        {
            return new Random().Next(1000, 9999).ToString();
        }

        public static string GetCurrentDate()
        {
            return DateTime.Now.ToString("ddMMyy");
        }
    }
}