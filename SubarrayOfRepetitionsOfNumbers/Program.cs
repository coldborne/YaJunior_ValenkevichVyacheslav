using System;
using System.Collections;

namespace SubarrayOfRepetitionsOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int size = 30;
            int[] rooms = new int[size];
            Random random = new Random();
            int maxValue = 10;

            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = random.Next(maxValue + 1);
                Console.Write(rooms[i] + " ");
            }

            Console.WriteLine();

            int currentRepetitionsCount = 1;
            int maxRepetitionsCount = 1;

            for (int i = 1; i < rooms.Length; i++)
            {
                if (rooms[i] == rooms[i - 1])
                {
                    currentRepetitionsCount++;
                }
                else
                {
                    currentRepetitionsCount = 1;
                }

                if (currentRepetitionsCount > maxRepetitionsCount)
                {
                    maxRepetitionsCount = currentRepetitionsCount;
                }
            }

            currentRepetitionsCount = 1;
            ArrayList mostRepeatedNumbers = new ArrayList();

            for (int i = 1; i < rooms.Length; i++)
            {
                if (rooms[i] == rooms[i - 1])
                {
                    currentRepetitionsCount++;
                }
                else
                {
                    currentRepetitionsCount = 1;
                }

                if (currentRepetitionsCount == maxRepetitionsCount)
                {
                    if (mostRepeatedNumbers.Contains(rooms[i - 1]) == false)
                    {
                        mostRepeatedNumbers.Add(rooms[i - 1]);
                    }
                }
            }

            if (mostRepeatedNumbers.Count > 0)
            {
                if (mostRepeatedNumbers.Count > 1)
                {
                    Console.Write("Самые повторяемые числа: ");

                    foreach (int number in mostRepeatedNumbers)
                    {
                        Console.Write(number + " ");
                    }

                    Console.WriteLine($"\nКоличество повторений - {maxRepetitionsCount}");
                }
                else
                {
                    Console.WriteLine($"Самое повторяемое число - {mostRepeatedNumbers[0]}, количество повторений - {maxRepetitionsCount}");
                }
            }

            Console.WriteLine();
            ExecuteWithoutArrayList();
        }

        private static void ExecuteWithoutArrayList()
        {
            const int size = 30;
            int[] rooms = new int[size];
            Random random = new Random();
            int maxValue = 10;

            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = random.Next(maxValue + 1);
                Console.Write(rooms[i] + " ");
            }

            Console.WriteLine();

            int currentRepetitionsCount = 1;
            int maxRepetitionsCount = 1;
            int mostRepeatedNumber = rooms[0];

            for (int i = 1; i < rooms.Length; i++)
            {
                if (rooms[i] == rooms[i - 1])
                {
                    currentRepetitionsCount++;
                }
                else
                {
                    currentRepetitionsCount = 1;
                }

                if (currentRepetitionsCount >= maxRepetitionsCount)
                {
                    mostRepeatedNumber = rooms[i - 1];
                    maxRepetitionsCount = currentRepetitionsCount;
                }
            }

            Console.WriteLine($"Самое повторяемое число - {mostRepeatedNumber}, количество повторений - {maxRepetitionsCount}");
        }
    }
}
