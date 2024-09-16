using System;

namespace Aquarium
{
    public static class UserUtils
    {
        public static Random Random { get; } = new Random();

        public static int ReadFishCount(Aquarium aquarium)
        {
            bool isInputInt = false;
            int number = 0;

            while (isInputInt == false)
            {
                string userInput = Console.ReadLine();
                isInputInt = int.TryParse(userInput, out number);

                if (isInputInt == false)
                {
                    Console.WriteLine("Вводить можно только целые числа");
                }
                else
                {
                    if (number <= 0 || number > aquarium.MaxFishAmount)
                    {
                        Console.WriteLine("Число должно быть больше 0 и меньше/равно " + aquarium.MaxFishAmount);

                        isInputInt = false;
                    }
                }
            }

            return number;
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
        
        public static string GenerateFishName()
        {
            const int nameLength = 5;
            const int StartSymbolIndex = 97;
            const int EndSymbolIndex = 122;

            string name = "";

            while (name.Length < nameLength)
            {
                char symbol = (char)UserUtils.Random.Next(StartSymbolIndex, EndSymbolIndex + 1);

                if (char.IsLetterOrDigit(symbol))
                {
                    name += symbol;
                }
            }

            return name;
        }
    }
}