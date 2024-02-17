using System;

namespace Shop.Providers
{
    public static class RandomValueProvider
    {
        private static Random _random = new Random();

        public static int GetRandomValue(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue + 1);
        }

        public static int GetRandomValue(int maxValue)
        {
            return _random.Next(maxValue + 1);
        }
    }
}