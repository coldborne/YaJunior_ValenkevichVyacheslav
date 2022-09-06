using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KansasCityShuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfEstimates = 10;

            int[] estimates = new int[sizeOfEstimates];

            Console.Write("Изначальный массив - ");

            for (int i = 0; i < estimates.Length; i++)
            {
                estimates[i] = i + 1;
                Console.Write(estimates[i] + " ");
            }

            Console.Write("\nМассив после перемешивания - ");

            Shuffle(estimates);

            for (int i = 0; i < estimates.Length; i++)
            {
                Console.Write(estimates[i] + " ");
            }

            Console.WriteLine();
        }

        private static int[] Shuffle(int[] array)
        {
            List<int> tempList = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                tempList.Add(array[i]);
            }

            int currentIndex = 0;

            while (tempList.Count > 0)
            {
                Random random = new Random();
                int tempIndex = random.Next(tempList.Count);
                int tempElement = tempList[tempIndex];

                array[currentIndex++] = tempElement;

                tempList.Remove(tempElement);
            }

            return array;
        }
    }
}
