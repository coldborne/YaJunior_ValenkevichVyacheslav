﻿using System;

namespace WorkingWithSpecificRowsAndColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] intMatrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int lineNumber = 2;
            int columnNumber = 1;

            int sumOfElements = CalculateSumOfElements(intMatrix, lineNumber);
            int productOfElements = CalculateProductOfElements(intMatrix, columnNumber);
            OutputMatrix(intMatrix);

            Console.WriteLine($"Сумма элементов {lineNumber}ой строки = {sumOfElements}");
            Console.WriteLine($"Произведение элементов {columnNumber}ого столбца = {productOfElements}");
        }

        private static int CalculateSumOfElements(int[,] intMatrix, int lineNumber)
        {
            int sumOfMatrixElements = 0;

            for (int i = 0; i < intMatrix.GetLength(0); i++)
            {
                if (i == lineNumber - 1)
                {
                    for (int j = 0; j < intMatrix.GetLength(1); j++)
                    {
                        sumOfMatrixElements += intMatrix[i, j];
                    }
                }
            }

            return sumOfMatrixElements;
        }

        private static int CalculateProductOfElements(int[,] intMatrix, int columnNumber)
        {
            int productOfElements = 1;

            for (int i = 0; i < intMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < intMatrix.GetLength(1); j++)
                {
                    if (j == columnNumber - 1)
                    {
                        productOfElements *= intMatrix[i, j];
                    }
                }
            }

            return productOfElements;
        }

        private static void OutputMatrix(int[,] intMatrix)
        {
            for (int i = 0; i < intMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < intMatrix.GetLength(1); j++)
                {
                    Console.Write(intMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
