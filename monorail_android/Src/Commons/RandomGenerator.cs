using System;

namespace monorail_android.Commons
{
    public static class RandomGenerator
    {
        public static string GenerateRandomNumber()
        {
            return new Random().Next(100, 999).ToString();
        }
    }
}