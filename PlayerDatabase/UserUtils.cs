using System;

namespace PlayerDatabase
{
    public class UserUtils
    {
        private static Random Random { get; } = new Random();

        public static string GenerateName()
        {
            const int nameLength = 5;
            string name = "";

            while (name.Length < nameLength)
            {
                char symbol = (char)Random.Next(97, 123);

                if (char.IsLetterOrDigit(symbol))
                {
                    name += symbol;
                }
            }

            return name;
        }

        public static int ReadCommand()
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
                else
                {
                    int commandsLength = Enum.GetNames(typeof(Commands)).Length;

                    if (userInputInt <= 0 || userInputInt > commandsLength)
                    {
                        Console.WriteLine("Недопустимое число");
                        isInputRight = false;
                    }
                }
            }

            return userInputInt;
        }

        public static int ReadInt()
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