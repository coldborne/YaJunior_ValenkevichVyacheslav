using System;

namespace ReadInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value = ReadInt();

            Console.WriteLine(value);
        }

        private static int ReadInt()
        {
            int value = 0;
            bool isIntValue = false;

            while (isIntValue == false)
            {
                Console.WriteLine("Введите число:");

                string userInput = Console.ReadLine();
                isIntValue = int.TryParse(userInput, out value);

                if (isIntValue == false)
                {
                    Console.WriteLine("Можно вводить только числа");
                }
            }

            return value;
        }
    }
}
