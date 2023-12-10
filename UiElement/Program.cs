using System;

namespace UiElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor colorOfBar = ConsoleColor.Green;

            int scalePercentage = GetScalePercentage();

            int positionX = 0;
            int positionY = Console.CursorTop;

            DrawBar(scalePercentage, colorOfBar, positionX, positionY);
        }

        private static int GetScalePercentage()
        {
            bool isScalePercentageValid = false;
            bool isValueValid;

            int minScalePercentageValue = 0;
            int maxScalePercentageValue = 100;

            int scalePercentage = 0;

            while (isScalePercentageValid == false)
            {
                Console.Write("Введите закрашенный процент: ");
                string userInput = Console.ReadLine();
                isValueValid = int.TryParse(userInput, out scalePercentage);

                if (isValueValid == false)
                {
                    Console.WriteLine("Можно вводить только целые числа");
                }
                else
                {
                    if (scalePercentage < minScalePercentageValue || scalePercentage > maxScalePercentageValue)
                    {
                        Console.WriteLine($"Процент должен быть от {minScalePercentageValue} до {maxScalePercentageValue}");
                    }
                    else
                    {
                        isScalePercentageValid = true;
                    }
                }
            }

            return scalePercentage;
        }

        private static void DrawBar(int scalePercentage, ConsoleColor color, int positionX, int positionY)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar;

            int maxUIScaleValue = 10;
            int maxPercentage = 100;
            double shadedAreaFraction = (double)scalePercentage / maxPercentage;
            int scaleValue = (int)(shadedAreaFraction * maxUIScaleValue);
            
            //Здесь передать количество повторений
            bar = FillBar(scaleValue, ' ');

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

            int blankArea= maxUIScaleValue - scaleValue;
            
            bar = FillBar(blankArea,' ');

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