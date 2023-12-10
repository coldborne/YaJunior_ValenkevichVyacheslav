using System;

namespace UiElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor colorOfBar = ConsoleColor.Green;

            int filledPercentage = GetScalePercentage();

            int positionX = 0;
            int positionY = Console.CursorTop;

            DrawBar(filledPercentage, colorOfBar, positionX, positionY);
        }

        private static int GetScalePercentage()
        {
            bool isfilledPercentageValueValid = false;
            bool isValueValid;

            int minFilledPercentageValue = 0;
            int maxFilledPercentageValue = 100;

            int filledPercentage = 0;

            while (isfilledPercentageValueValid == false)
            {
                Console.Write("Введите закрашенный процент: ");
                string userInput = Console.ReadLine();
                isValueValid = int.TryParse(userInput, out filledPercentage);

                if (isValueValid == false)
                {
                    Console.WriteLine("Можно вводить только целые числа");
                }
                else
                {
                    if (filledPercentage < minFilledPercentageValue || filledPercentage > maxFilledPercentageValue)
                    {
                        Console.WriteLine(
                            $"Процент должен быть от {minFilledPercentageValue} до {maxFilledPercentageValue}");
                    }
                    else
                    {
                        isfilledPercentageValueValid = true;
                    }
                }
            }

            return filledPercentage;
        }

        private static void DrawBar(int filledPercentage, ConsoleColor color, int positionX, int positionY)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar;

            int maxUIScaleValue = 10;
            int maxPercentage = 100;
            double shadedAreaFraction = (double)filledPercentage / maxPercentage;
            int filledScaleValue = (int)(shadedAreaFraction * maxUIScaleValue);

            bar = FillBar(filledScaleValue, ' ');

            if (positionX < 0 || positionY < 0)
            {
                Console.SetCursorPosition(0, 0);
            }
            else
            {
                Console.SetCursorPosition(positionX, positionY);
            }

            Console.Write("[");
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            int blankArea = maxUIScaleValue - filledScaleValue;

            bar = FillBar(blankArea, ' ');

            Console.WriteLine(bar + "]");
        }

        private static string FillBar(int symbolCount, char fillSymbol)
        {
            string bar = string.Empty;

            for(int i = 0; i < symbolCount; i++)
            {
                bar += fillSymbol;
            }

            return bar;
        }
    }
}