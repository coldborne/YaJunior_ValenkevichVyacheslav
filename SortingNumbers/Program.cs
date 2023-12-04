using System;
using System.Linq;

namespace SortingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lowerLimit = 10;
            int upperLimit = 20;

            Random random = new Random();
            int size = random.Next(lowerLimit, upperLimit + 1);
            int[] numbers = new int[size];

            Console.WriteLine("Первоначальный массив:");

            int maxNumber = upperLimit;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(maxNumber) + 1;

                Console.Write(numbers[i] + " ");
            }

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int tempValue = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = tempValue;
                    }
                }
            }

            Console.WriteLine("\n\nОтсортированный массив:");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
