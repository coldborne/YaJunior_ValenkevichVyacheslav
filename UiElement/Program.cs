using System;

namespace UiElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxHealth = 500;
            int health = 600;
            ConsoleColor colorOfBar = ConsoleColor.Green;
            int positionX = 0;
            int positionY = 0;

            int scalePercentage = CalculatePercentage(health, maxHealth);

            DrawBar(scalePercentage, colorOfBar, positionX, positionY);
        }

        private static int CalculatePercentage(int currentValue, int maxValue)
        {
            int maximumPercentage = 100;
            int percentage = (int)(maximumPercentage * (float)currentValue / maxValue);

            if (percentage >= 0 & percentage <= maximumPercentage)
            {
                return percentage;
            }
            
            return percentage < 0 ? 0 : 100;
        }

        private static void DrawBar(int scalePercentage, ConsoleColor color, int positionX, int positionY)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = "";

            int maxUIScaleValue = 10;
            int scaleValue = scalePercentage / maxUIScaleValue;

            for (int i = 0; i < scaleValue; i++)
            {
                bar += ' ';
            }

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

            bar = "";

            for (int i = scaleValue; i < maxUIScaleValue; i++)
            {
                bar += ' ';
            }

            Console.WriteLine(bar + "]");
        }
    }
}
