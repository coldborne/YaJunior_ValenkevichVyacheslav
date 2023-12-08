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
                        Console.WriteLine("Процент должен быть от 0 до 100");
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
            int scaleValue = scalePercentage / maxUIScaleValue;

            bar = FillBar(0, scaleValue, ' ');

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

            bar = FillBar(scaleValue, maxUIScaleValue, ' ');

            Console.WriteLine(bar + "]");
        }

        private static string FillBar(int startPosition, int endPositiob, char fillSymbol)
        {
            string bar = string.Empty;

            for(int i = startPosition; i < endPositiob; i++)
            {
                bar += fillSymbol;
            }

            return bar;
        }
    }
}