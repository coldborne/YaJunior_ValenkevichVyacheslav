using System;

namespace Aquarium
{
    public static class UserUtils
    {
        private static Random _random = new Random();

        public static int GetRandomValue(int startValue, int endValue)
        {
            return _random.Next(startValue, endValue);
        }
        
        public static int GetRandomValue(int endValue)
        {
            return _random.Next(endValue);
        }

        public static int ReadFishCount(int maxFishAmount)
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
                    if (number <= 0 || number > maxFishAmount)
                    {
                        Console.WriteLine("Число должно быть больше 0 и меньше/равно " + maxFishAmount);

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
    }
}