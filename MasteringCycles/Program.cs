using System;

namespace MasteringCycles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Какое сообщение вывести?");
            string message = Console.ReadLine();

            Console.WriteLine("Сколько раз вывести Ваше сообщение?");
            int numberOfMessages = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberOfMessages; i++)
            {
                Console.WriteLine(message);
            }
        }
    }
}
