using System;
using System.Collections.Generic;

namespace PersonnelAccountingPRO
{
    internal class Program
    {
        private static List<Dossier> _dossiers = new List<Dossier>();

        static void Main(string[] args)
        {
            bool isProgramWork = true;

            Console.WriteLine("Добро пожаловать в нашу секретную библиотеку!\nУ нас можно:");

            while (isProgramWork)
            {
                Console.WriteLine("1 - Добавить досье, 2 - Вывести все досье, 3 - Удалить одно досье, 4 - Выход");
                
                Console.WriteLine("Чтобы перейти к нужному функционалу, введите нужную цифру");
                int commandNumber = UserUtils.ReadIntValue();

                switch (commandNumber)
                {
                    case 1:
                        AddDossier();
                        break;
                    case 2:
                        ShowAllDossiers();
                        break;
                    case 3:
                        DeleteDossier();
                        break;
                    case 4:
                        isProgramWork = false;
                        break;
                    default:
                        Console.WriteLine("Недоступная команда");
                        break;
                }
            }
        }

        private static void AddDossier()
        {
            Dossier dossier = CreateDossier();

            _dossiers.Add(dossier);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Досье добавлено");
            Console.ResetColor();
        }

        private static void ReadData(ref string fullName, ref string position)
        {
            bool isFullNameCorrect = false;

            while (isFullNameCorrect == false)
            {
                Console.WriteLine("Введите фио");
                fullName = Console.ReadLine();

                isFullNameCorrect = IsContainsFullData(fullName);

                if (isFullNameCorrect == false)
                {
                    Console.WriteLine("ФИО должно содержать фамилию, имя и отчество (при наличии)");
                }
            }

            bool isPositionCorrect = false;

            while (isPositionCorrect == false)
            {
                Console.WriteLine("Введите должность человека");
                position = Console.ReadLine().Trim();

                if (position == "")
                {
                    Console.WriteLine("Должность не может быть пустой");
                }
                else
                {
                    isPositionCorrect = true;
                }
            }
        }

        private static bool IsContainsFullData(string fullName)
        {
            string[] words = fullName.Split(' ');
            const int minimumAmountWords = 2;
            const int maximumAmountWords = 3;

            return words.Length >= minimumAmountWords && words.Length <= maximumAmountWords;
        }

        private static Dossier CreateDossier()
        {
            string fullName = null;
            string position = null;

            ReadData(ref fullName, ref position);

            return new Dossier(fullName, position);
        }

        private static void ShowAllDossiers()
        {
            if (_dossiers.Count == 0)
            {
                Console.WriteLine("Ни одно досье пока не добавлено");
            }
            else
            {
                foreach (var dossier in _dossiers)
                {
                    Console.WriteLine($"ФИО: {dossier.Fullname}  позиция: {dossier.Position}");
                }

                Console.WriteLine();
            }
        }

        private static void DeleteDossier()
        {
            if (_dossiers.Count == 0)
            {
                Console.WriteLine("Ни одно досье пока не добавлено");
            }
            else
            {
                Console.WriteLine($"В системе зарегистрировано {_dossiers.Count} досье");
                
                Console.WriteLine("Укажите ФИО из досье, которое желаете удалить");
                string fullname = Console.ReadLine();

                Console.WriteLine("Укажите должность из досье, которое желаете удалить");
                string position = Console.ReadLine();

                Dossier dossier = _dossiers.Find(x => x.Fullname == fullname && x.Position == position);

                if (dossier != null)
                {
                    _dossiers.Remove(dossier);
                }
                else
                {
                    Console.WriteLine("Досье с такими данными не найдено");
                }
            }
        }
    }
}