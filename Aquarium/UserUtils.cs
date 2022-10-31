using System;

namespace Aquarium
{
    public static class UserUtils
    {
        private static Random _random = new Random();

        public static Random Random => _random;

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
                    if (number <= 0 || number > aquarium.MaxFishesAmount)
                    {
                        Console.WriteLine("Число должно быть больше нуля и меньше/равно " + aquarium.MaxFishesAmount);

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
                    int CommandsLength = Enum.GetNames(typeof(Commands)).Length;
                    if (userInputInt <= 0 || userInputInt > CommandsLength)
                    {
                        Console.WriteLine("Недопустимое число");
                        isInputRight = false;
                    }
                }
            }

            return userInputInt;
        }
    }
}