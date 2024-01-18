using System;

namespace BookStorage
{
    public static class ConsoleColorizer
    {
        public static void WriteLineColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WritePartiallyColored(string message, string coloredPart, ConsoleColor color)
        {
            string[] parts = message.Split(new[] { coloredPart }, StringSplitOptions.None);

            for(int i = 0; i < parts.Length; i++)
            {
                Console.Write(parts[i]);

                if (i < parts.Length - 1)
                {
                    WriteColored(coloredPart, color);
                }
            }

            Console.WriteLine();
        }

        private static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}