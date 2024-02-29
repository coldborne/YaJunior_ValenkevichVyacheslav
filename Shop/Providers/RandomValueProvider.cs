using System;

namespace Shop.Providers
{
    public class RandomValueProvider
    {
        private static Random _random = new Random();

        public int GetRandomValue(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue + 1);
        }

        public int GetRandomValue(int maxValue)
        {
            return _random.Next(maxValue + 1);
        }
    }
}