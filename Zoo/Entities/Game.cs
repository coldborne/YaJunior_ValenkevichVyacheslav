using System;
using System.Collections.Generic;
using System.IO;
using Zoo.Entities.Factories;

namespace Zoo.Entities
{
    public class Game
    {
        private Zoo _zoo;
        private ZooView _zooView;

        public Game(Zoo zoo, ZooView zooView)
        {
            _zoo = zoo;
            _zooView = zooView;
        }

        public void Play()
        {
            const int ExitChoice = 0;

            InitializeAviaries();

            bool isExit = false;

            _zooView.ShowStartWindow();

            while (isExit == false)
            {
                List<Aviary> aviaries = _zoo.GetAviaries();
                _zooView.DisplayMainMenu(aviaries);

                Console.Write("Ваш выбор: ");
                string input = Console.ReadLine();

                bool canGetUserChoice = int.TryParse(input, out int userChoice);

                if (canGetUserChoice)
                {
                    if (userChoice == ExitChoice)
                    {
                        isExit = true;
                    }
                    else
                    {
                        int avairyIndex = userChoice - 1;

                        if (_zoo.TryGetAviary(avairyIndex, out Aviary aviary))
                        {
                            string[] asciiArt;
                            string errorInfo;
                            string fileName = string.Empty;

                            switch (aviary.Name)
                            {
                                case AviaryNames.Capybara:
                                    fileName = "CabybaraPicture.txt";
                                    break;

                                case AviaryNames.Cat:
                                    fileName = "CatPicture.txt";
                                    break;

                                case AviaryNames.Giraffe:
                                    fileName = "GiraffePicture.txt";
                                    break;

                                case AviaryNames.Penguin:
                                    fileName = "PenguinPicture.txt";
                                    break;
                            }

                            if (fileName != string.Empty)
                            {
                                if (TryGetAsciiArt(fileName, out asciiArt, out errorInfo))
                                {
                                    _zooView.DisplayAvairyInfo(aviary, asciiArt);
                                    _zooView.DisplayAnimalsActions(aviary);
                                }
                                else
                                {
                                    Console.WriteLine(errorInfo);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Нет изображения для этого вольера.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный выбор. Нажмите любую клавишу для продолжения.");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                }
            }
        }

        private bool TryGetAsciiArt(string fileName, out string[] lines, out string errorInfo)
        {
            lines = null;
            errorInfo = "";

            try
            {
                string path = Path.Combine("Resources", "Pictures", "PicturesOfAviaries", fileName);

                if (File.Exists(path))
                {
                    lines = File.ReadAllLines(path);
                    return true;
                }

                errorInfo = $"Файл {path} не найден.";
                return false;
            }
            catch (Exception ex)
            {
                errorInfo = "Ошибка при загрузке ASCII-арта: " + ex.Message;
                return false;
            }
        }

        private void InitializeAviaries()
        {
            AnimalFactory animalFactory = new AnimalFactory();
            AviaryFactory aviaryFactory = new AviaryFactory();

            List<Aviary> aviaries = new List<Aviary>();

            Aviary capybaraEnclosure = aviaryFactory.CreateAviary(AviaryNames.Capybara);
            capybaraEnclosure.AddAnimal(animalFactory.CreateCapybara("Капибара Кэпи", "Мужской", "Фью-фью"));
            capybaraEnclosure.AddAnimal(animalFactory.CreateCapybara("Капибара Бара", "Женский", "Фью-фью"));
            aviaries.Add(capybaraEnclosure);

            Aviary catEnclosure = aviaryFactory.CreateAviary(AviaryNames.Cat);
            catEnclosure.AddAnimal(animalFactory.CreateCat("Мурка", "Женский", "Мяу"));
            catEnclosure.AddAnimal(animalFactory.CreateCat("Барсик", "Мужской", "Мяу"));
            aviaries.Add(catEnclosure);

            Aviary giraffeEnclosure = aviaryFactory.CreateAviary(AviaryNames.Giraffe);
            giraffeEnclosure.AddAnimal(animalFactory.CreateGiraffe("Жираф Длинношей", "Мужской", "Мммм", 5.5));
            aviaries.Add(giraffeEnclosure);

            Aviary penguinEnclosure = aviaryFactory.CreateAviary(AviaryNames.Penguin);
            penguinEnclosure.AddAnimal(animalFactory.CreatePenguin("Пинг", "Мужской", "Кря-кря"));
            penguinEnclosure.AddAnimal(animalFactory.CreatePenguin("Понг", "Женский", "Кря-кря"));
            aviaries.Add(penguinEnclosure);

            foreach (Aviary aviary in aviaries)
            {
                _zoo.AddAviary(aviary);
            }
        }
    }
}