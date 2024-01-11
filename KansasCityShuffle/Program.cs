using System;
using System.Collections.Generic;

namespace KansasCityShuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfEstimates = 10;

            int[] estimates = new int[sizeOfEstimates];

            for(int i = 0; i < estimates.Length; i++)
            {
                estimates[i] = i + 1;
            }

            Console.Write("Изначальный массив - ");
            ShowEstimates(estimates);

            Shuffle(estimates);

            Console.Write("\nМассив после перемешивания - ");
            ShowEstimates(estimates);

            Console.WriteLine();
        }

        private static void Shuffle(int[] array)
        {
            List<int> tempList = new List<int>(array);

            int currentIndex = 0;
            Random random = new Random();

            while (tempList.Count > 0)
            {
                int tempIndex = random.Next(tempList.Count);
                int tempElement = tempList[tempIndex];

                if (tempIndex != currentIndex)
                {
                    array[currentIndex++] = tempElement;

                    tempList.Remove(tempElement);
                }
            }
        }

        private static void ShowEstimates(int[] estimates)
        {
            for(int i = 0; i < estimates.Length; i++)
            {
                Console.Write(estimates[i] + " ");
            }
        }
    }
}