using System;

namespace SumOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int randomNumber = random.Next(101);
            int sumOfNumbers = 0;

            Console.WriteLine($"Вам выпало число - {randomNumber}");

            for (int currentNumber = 1; currentNumber <= randomNumber; currentNumber++)
            {
                if (currentNumber % 3 == 0 || currentNumber % 5 == 0)
                {
                    sumOfNumbers += currentNumber;
                }
            }

            Console.WriteLine($"Сумма чисел кратных 3 и 5 в диапозоне от 1 до {randomNumber} = {sumOfNumbers}");
        }
    }
}
