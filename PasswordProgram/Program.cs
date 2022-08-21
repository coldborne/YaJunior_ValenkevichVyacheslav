using System;

namespace PasswordProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int attemptsCount = 3;
            int remainingAttempts = attemptsCount;
            string correctPassword = "JoJo";
            string secretMessage = "It`s me - DIO";

            Console.WriteLine("Введите пароль");

            for (int i = attemptsCount; i > 0; i--)
            {
                string userInput = Console.ReadLine();

                if (userInput == correctPassword)
                {
                    Console.WriteLine("Верно");
                    Console.WriteLine("Секретное сообщение - " + secretMessage);
                    i = 0;
                }
                else
                {
                    remainingAttempts--;
                    Console.WriteLine("Неверно");
                }
            }

            if (remainingAttempts == 0)
            {
                Console.WriteLine("Увы, попробуйте в другой раз");
            }
        }
    }
}
