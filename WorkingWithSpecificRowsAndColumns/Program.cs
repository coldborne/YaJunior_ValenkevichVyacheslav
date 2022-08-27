using System;

namespace WorkingWithSpecificRowsAndColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int LinesAmount = 3;
            const int ColumnsAmount = 3;
            int[,] matrix = new int[LinesAmount, ColumnsAmount] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            int lineNumber = 2;
            int columnNumber = 1;

            int sumOfElements = CalculateSum(matrix, lineNumber);
            int productOfElements = CalculateProduc(matrix, columnNumber);
            OutputMatrix(matrix);

            Console.WriteLine($"Сумма элементов {lineNumber}ой строки = {sumOfElements}");
            Console.WriteLine($"Произведение элементов {columnNumber}ого столбца = {productOfElements}");
        }

        private static int CalculateSum(int[,] matrix, int lineNumber)
        {
            int sumOfMatrixElements = 0;
            int matrixLength = matrix.GetLength(0);
            int matrixHeight = matrix.GetLength(1);

            if (lineNumber <= matrixLength && lineNumber > 0)
            {
                for (int i = 0; i < matrixLength; i++)
                {
                    if (i == lineNumber - 1)
                    {
                        for (int j = 0; j < matrixHeight; j++)
                        {
                            sumOfMatrixElements += matrix[i, j];
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Такой строки в матрице нет");
            }

            return sumOfMatrixElements;
        }

        private static int CalculateProduc(int[,] matrix, int columnNumber)
        {
            int productOfElements = 1;
            int matrixLength = matrix.GetLength(0);
            int matrixHeight = matrix.GetLength(1);

            if (columnNumber <= matrixLength && columnNumber > 0)
            {
                for (int i = 0; i < matrixLength; i++)
                {
                    for (int j = 0; j < matrixHeight; j++)
                    {
                        if (j == columnNumber - 1)
                        {
                            productOfElements *= matrix[i, j];
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Такого столбца в матрице нет");
            }

            return productOfElements;
        }

        private static void OutputMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
