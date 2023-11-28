using System;

namespace LargestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers = new int[10, 10];

            InitializeMatrix(numbers);

            OutputMatrix(numbers);

            int maxValueInMatrix = FindMaximumElement(numbers);
            int newValue = 0;

            ReplaceMaxNumberInMatrix(numbers, maxValueInMatrix, newValue);

            Console.WriteLine("\nМаксимальный элемент в матрице - " + maxValueInMatrix + "\n");

            OutputMatrix(numbers);
        }

        private static void OutputMatrix(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int FindMaximumElement(int[,] matrix)
        {
            int maxValue = matrix[0, 0];

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (maxValue < matrix[i, j])
                    {
                        maxValue = matrix[i, j];
                    }
                }
            }

            return maxValue;
        }

        private static void ReplaceMaxNumberInMatrix(int[,] matrix, int maxValue, int newValue)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == maxValue)
                    {
                        matrix[i, j] = newValue;
                    }
                }
            }
        }

        private static void InitializeMatrix(int[,] matrix)
        {
            Random random = new Random();
            int maximumCellValue = 100;

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(0, maximumCellValue) + 1;
                }
            }
        }
    }
}