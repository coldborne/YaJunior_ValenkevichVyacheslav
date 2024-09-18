using System;
using System.Collections.Generic;

namespace Zoo.Entities
{
    public class ZooView
    {
        public void ShowStartWindow()
        {
            Console.Clear();
            Console.WriteLine("********************************************");
            Console.WriteLine("*                                          *");
            Console.WriteLine("*      Добро пожаловать в Зоопарк!         *");
            Console.WriteLine("*                                          *");
            Console.WriteLine("********************************************");
            Console.WriteLine("\nНажмите любую клавишу, чтобы начать...");
            Console.ReadKey();
        }

        public void DisplayMainMenu(List<Aviary> aviaries)
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("               Меню Зоопарка                ");
            Console.WriteLine("============================================");
            Console.WriteLine("Выберите вольер для посещения:\n");

            for (int avairyIndex = 0; avairyIndex < aviaries.Count; avairyIndex++)
            {
                int avairyNumber = avairyIndex + 1;
                string avairyName = aviaries[avairyIndex].Name;

                Console.WriteLine($"{avairyNumber}. {avairyName}");
            }

            Console.WriteLine("0. Выход");
            Console.WriteLine("============================================\n");
        }

        public void DisplayAvairyInfo(Aviary aviary, string[] avairyAsciiArt)
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine($"   Вы подошли к {aviary.Name}   ");
            Console.WriteLine("============================================\n");

            DisplayAsciiArt(avairyAsciiArt);

            Console.WriteLine($"\nКоличество животных: {aviary.AnimalCount}");
            Console.WriteLine("Информация о животных:");

            Console.Write(aviary);

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню.");
            Console.ReadKey();
        }

        public void DisplayAsciiArt(string[] avairyAsciiArt)
        {
            foreach (string line in avairyAsciiArt)
            {
                Console.WriteLine(line);
            }
        }
    }
}