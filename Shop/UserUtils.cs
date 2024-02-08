using System;

namespace Shop
{
    public enum Commands : byte
    {
        First = 1,
        Second,
        Third,
        Fourth,
        Five,
        Six,
        Seven
    }

    public class UserUtils
    {
        public int ReadInt()
        {
            int userInputInt = 0;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                string userInput = Console.ReadLine();

                isInputRight = int.TryParse(userInput, out userInputInt);

                if (isInputRight == false)
                {
                    Console.WriteLine("Можно вводить только целые числа");
                }
            }

            return userInputInt;
        }

        public float ReadFloat()
        {
            float userInputFloat = 0;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                string userInput = Console.ReadLine();

                isInputRight = float.TryParse(userInput, out userInputFloat);

                if (isInputRight == false)
                {
                    Console.WriteLine("Можно вводить только целые числа");
                }
            }

            return userInputFloat;
        }
    }
}