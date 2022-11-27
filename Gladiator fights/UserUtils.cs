using System;

namespace Gladiator_fights
{
    public class UserUtils
    {
        private static Random _random = new Random();

        public static Random Random => _random;

        public static int ReadUserInput()
        {
            bool isUserInputRight = false;
            int userInputInt = 0;

            while (isUserInputRight == false)
            {
                string userInput = Console.ReadLine();
                isUserInputRight = int.TryParse(userInput, out userInputInt);

                if (isUserInputRight == false)
                {
                    Console.WriteLine("Можно вводить только целые числа");
                }
            }

            return userInputInt;
        }
        
        public static int SelectFighter(Arena arena)
        {
            int selectedFighter = 0;
            bool isNumberOfFigtherRight = false;

            while (isNumberOfFigtherRight == false)
            {
                selectedFighter = UserUtils.ReadUserInput();

                if (selectedFighter <= 0 || selectedFighter > arena.GetFightersCount())
                {
                    Console.WriteLine("Бойца под таким номером нет");
                }
                else
                {
                    isNumberOfFigtherRight = true;
                }
            }

            return selectedFighter;
        }
    }
}