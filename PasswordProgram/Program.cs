using System;

namespace PasswordProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int attemptsCount = 3;
            string correctPassword = "JoJo";
            string secretMessage = "It`s me - DIO";

            Console.WriteLine("Введите пароль");

            while (attemptsCount > 0)
            {
                string userInput = Console.ReadLine();
                if (userInput == correctPassword)
                {
                    Console.WriteLine("Верно");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверно");
                    attemptsCount--;
                }
            }

            if (attemptsCount > 0)
            {
                Console.WriteLine(secretMessage);
            }
            else
            {
                Console.WriteLine("Увы, попробуйте в другой раз");
            }
        }
    }
}
