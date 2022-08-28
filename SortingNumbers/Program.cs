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

            int maxNumber = 20;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(maxNumber) + 1;

                Console.Write(numbers[i] + " ");
            }

            numbers = MergeSort(numbers);

            Console.WriteLine("\n\nОтсортированный массив:");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();
        }

        static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers;
            }

            int middle = numbers.Length / 2;

            int[] first = MergeSort(numbers.Take(middle).ToArray());
            int[] second = MergeSort(numbers.Skip(middle).ToArray());

            return Merge(first, second);
        }

        static int[] Merge(int[] first, int[] second)
        {
            int indexMinOfFirst = 0, indexMinOfSecond = 0;
            int[] merged = new int[first.Length + second.Length];

            for (int i = 0; i < merged.Length; ++i)
            {
                if (indexMinOfFirst < first.Length && indexMinOfSecond < second.Length)
                {
                    merged[i] = first[indexMinOfFirst] > second[indexMinOfSecond] ? second[indexMinOfSecond++] : first[indexMinOfFirst++];
                }
                else
                {
                    merged[i] = indexMinOfSecond < second.Length ? second[indexMinOfSecond++] : first[indexMinOfFirst++];
                }
            }

            return merged;
        }
    }
}
