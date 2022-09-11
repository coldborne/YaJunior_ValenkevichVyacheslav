using System;

namespace UiElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxHealth = 500;
            int health = 300;

            ConsoleColor colorOfBar = ConsoleColor.Green;
            int positionX = 0;
            int positionY = 0;

            DrawBar(health, maxHealth, colorOfBar, positionX, positionY);
        }

        private static void DrawBar(int currentScaleValue, int maxScaleValue, ConsoleColor color, int positionX, int positionY)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = "";

            int scalePercentage = (int)(100 * (float)currentScaleValue / (float)maxScaleValue);
            int maxUIScaleValue = 10;

            int scaleValue = scalePercentage / 10;

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
