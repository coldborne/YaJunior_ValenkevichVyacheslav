using System;

namespace Passenger_Train_Configurator
{
    public static class RandomProvider
    {
        private static Random _random = new Random();

        public static int Next(int minimum, int maximum)
        {
            return _random.Next(minimum, maximum + 1);
        }

        public static int Next(int maximum)
        {
            return _random.Next(maximum + 1);
        }
    }
}