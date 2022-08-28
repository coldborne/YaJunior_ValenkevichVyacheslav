using System;

namespace ShiftArrayValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersLength = 10;
            int[] numbers = new int[numbersLength];

            Random random = new Random();
            int maxValue = 10;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(maxValue + 1);
                Console.Write(numbers[i] + " ");
            }

            Console.Write("\nВведите шаг, на который нужно сдвинуть влево числа: ");

            int step = Convert.ToInt32(Console.ReadLine());

            if (step < 0)
            {
                Console.WriteLine("В данной реализации доступен только сдвиг влево, поэтому отрицательный сдвиг тут не прокатит");
            }
            else
            {
                for (int i = 0; i < step; i++)
                {
                    int tempValue = numbers[0];

                    for (int j = 0; j < numbers.Length - 1; j++)
                    {
                        numbers[j] = numbers[j + 1];
                    }

                    numbers[numbers.Length - 1] = tempValue;
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
