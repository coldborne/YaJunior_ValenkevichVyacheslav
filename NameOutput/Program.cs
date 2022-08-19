using System;

namespace NameOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите своё имя");
            string name = Console.ReadLine();

            Console.WriteLine("Введите символ для рамки");
            char symbolForFrame = Console.ReadKey().KeyChar;
            Console.WriteLine();

            int nameLength = name.Length;
            int stringsInFrameAmount = 3;
            int columnsInFrameAmount = nameLength + 2;

            for (int i = 0; i < stringsInFrameAmount; i++)
            {
                if (i == 0 || i == stringsInFrameAmount - 1)
                {
                    for (int j = 0; j < columnsInFrameAmount; j++)
                    {
                        Console.Write(symbolForFrame);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(symbolForFrame + name + symbolForFrame);
                }
            }
        }
    }
}
