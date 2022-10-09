using System;

namespace BookStorage
{
    public enum Commands: byte
    {
        First = 1,
        Second,
        Third,
        Fourth,
        Fifth
    }
    
    public static class UserUtils
    {
        private static int _currentYear = DateTime.Now.Year;
        
        public static string ReadString()
        {
            string userInput = null;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                userInput = Console.ReadLine();
                
                if (userInput == null || userInput.Trim() == "")
                {
                    Console.WriteLine("Строка должна содержать хотя бы один символ неравный пробелу");
                }
                else
                {
                    isInputRight = true;
                }
            }

            return userInput.Trim();
        }
        
        public static int ReadInt()
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
                    if (userInputInt > _currentYear)
                    {
                        Console.WriteLine(
                            $"Текущий год - {_currentYear}, год выпуска не может быть больше текущего года");
                        Console.WriteLine("Попробуйте ещё раз");

                        isInputRight = false;
                    }
                }
            }

            return userInputInt;
        }
    }
}