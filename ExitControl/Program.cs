using System;

namespace ExitControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string messageToComplete = "exit";
            bool enteredCorrectMessage = false;

            Console.WriteLine("Чтобы завершить программу, нужно ввести \"exit\"");

            while(enteredCorrectMessage == false)
            {
                Console.WriteLine("Введите сообщение");
                string userMessage = Console.ReadLine().ToLower();

                if(userMessage == messageToComplete)
                {
                    Console.WriteLine("Завершаем программу");
                    enteredCorrectMessage = true;
                    break;
                }
                else
                {
                    Console.WriteLine("По такому сообщению программа не завершится");
                    continue;
                }
            }
        }
    }
}
