using System;

namespace Multiples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maximumForMultiplier = 27;
            int multiplier = random.Next(maximumForMultiplier) + 1;

            Console.WriteLine($"Число N = {multiplier}");

            int lowerLimit = 100;
            int upperLimit = 999;
            int multiplesOfMultiplierCount = 0;

            int temporaryVariable = multiplier;
            while (temporaryVariable < lowerLimit)
            {
                temporaryVariable += multiplier;
            }

            for (; temporaryVariable < upperLimit; temporaryVariable += multiplier)
            {
                multiplesOfMultiplierCount++;
            }

            Console.WriteLine($"Количество чисел, кратных {multiplier} в диапозоне от {lowerLimit} до {upperLimit} = {multiplesOfMultiplierCount}");
        }
    }
}
