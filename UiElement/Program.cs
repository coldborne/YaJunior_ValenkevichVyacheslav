using System;

namespace UiElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int percent = 40;
            ConsoleColor colorOfBar = ConsoleColor.DarkYellow;
            int positionX = 0;
            int positionY = 0;

            DrawBar(percent, colorOfBar, positionX, positionY);
        }

        private static void DrawBar(int value, ConsoleColor color, int positionX, int positionY)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = "";

            value /= 10;

            for (int i = 0; i < value; i++)
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

            int maxValue = 10;

            for (int i = value; i < maxValue; i++)
            {
                bar += ' ';
            }

            Console.WriteLine(bar + "]");
        }
    }
}
