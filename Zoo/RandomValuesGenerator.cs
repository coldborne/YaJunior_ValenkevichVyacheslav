using System;

namespace Zoo
{
    public static class RandomValuesGenerator
    {
        private static Random _random = new Random();

        public static int GenerateRandomNumber(int from, int to)
        {
            return _random.Next(from, to + 1);
        }
    }
}