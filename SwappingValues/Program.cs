using System;

namespace SwappingValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string surname = "Slavka";
            string name = "Valenkevich";

            Console.WriteLine($"Фамилия: {surname}\nИмя: {name}\n");

            string temporaryString = surname;
            surname = name;
            name = temporaryString;

            Console.WriteLine($"Фамилия: {surname}\nИмя: {name}\n");
        }
    }
}
