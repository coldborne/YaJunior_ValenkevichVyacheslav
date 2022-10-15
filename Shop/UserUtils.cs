using System;

namespace Shop
{
    public enum Commands: byte
    {
        First = 1,
        Second,
        Third,
        Fourth
    }
    
    public class UserUtils
    {
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
            }

            return userInputInt;
        }
        
        public static int ReadNumberOfEmployees()
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
                    if (userInputInt <= 0)
                    {
                        Console.WriteLine("Количество сотрудников не может быть отрицательным или равным нулю");
                    }
                }
            }

            return userInputInt;
        }
    }
}