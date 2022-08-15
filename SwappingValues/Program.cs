using System;

namespace SwappingValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String surname = "Slavka";
            String name = "Valenkevich";

            Console.WriteLine($"Фамилия: {surname}\nИмя: {name}\n");

            String temporaryString = surname;
            surname = name;
            name = temporaryString;

            Console.WriteLine($"Фамилия: {surname}\nИмя: {name}\n");
        }
    }
}
