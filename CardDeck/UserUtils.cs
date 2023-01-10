using System;

namespace CardDeck
{
    public static class UserUtils
    {
        private static Random _random = new Random();

        public static int GetRandomInt(int minNumber, int maxNumber)
        {
            return _random.Next(minNumber, maxNumber);
        }

        public static int ReadInt()
        {
            bool isInputRight = false;

            int number = 0;

            while (isInputRight == false)
            {
                string userInput = Console.ReadLine();

                isInputRight = int.TryParse(userInput, out number);

                if (isInputRight == false)
                {
                    Console.WriteLine("Можно вводить только целое число");
                }
            }

            return number;
        }
    }
}