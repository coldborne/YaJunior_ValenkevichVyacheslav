using System;
using System.Collections.Generic;
using Zoo.Entities.Animals;

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

        public void DisplayAnimalsActions(Aviary aviary)
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine($"   Наблюдение за {aviary.Name}   ");
            Console.WriteLine("============================================\n");
            Console.WriteLine("Животные в вольере начинают свои действия!");

            Random random = new Random();
            List<Animal> animals = aviary.GetAnimals();
            int minActionCount = 1;

            foreach (Animal animal in animals)
            {
                int maxActionCount = animal.GetActions().Count;
                int actionCount = random.Next(minActionCount, maxActionCount + 1);
                List<Func<string>> actions = animal.GetActions();

                for (int actionNumber = 1; actionNumber <= actionCount; actionNumber++)
                {
                    int actionIndex = random.Next(actions.Count);
                    string actionResult = actions[actionIndex]();
                    Console.WriteLine(actionResult);
                }
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }
    }
}