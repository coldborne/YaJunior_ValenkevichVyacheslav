using System;

namespace SumOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int upperLimitOfRandom = 100;
            int randomNumber = random.Next(upperLimitOfRandom + 1);
            int firstDivider = 3;
            int secondDivider = 5;
            int sumOfNumbers = 0;

            Console.WriteLine($"Вам выпало число - {randomNumber}");

            for (int currentNumber = 0; currentNumber <= randomNumber; currentNumber++)
            {
                if (currentNumber % firstDivider == 0 || currentNumber % secondDivider == 0)
                {
                    sumOfNumbers += currentNumber;
                }
            }

            Console.WriteLine($"Сумма чисел кратных {firstDivider} и {secondDivider} в диапозоне от 1 до {randomNumber} = {sumOfNumbers}");
        }
    }
}
