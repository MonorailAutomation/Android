using System;

namespace monorail_android.Commons
{
    public static class RandomGenerator
    {
        public static string GenerateRandomNumber()
        {
            return new Random().Next(100, 999).ToString();
        }

        public static string GenerateRandomString()
        {
            return DateTime.Now.ToString("dd/MM/yyyy") + " " + new Random().Next(10, 99);
        }
    }
}