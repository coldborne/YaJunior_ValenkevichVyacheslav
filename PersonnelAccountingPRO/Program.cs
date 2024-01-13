using System;
using System.Collections.Generic;

namespace PersonnelAccountingPRO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dossiers = new Dictionary<string, string>();
            bool isProgramWork = true;

            Console.WriteLine("Добро пожаловать в нашу секретную библиотеку!\nУ нас можно:");

            while (isProgramWork)
            {
                Console.WriteLine("1 - Добавить досье, 2 - Вывести все досье, 3 - Удалить одно досье, 4 - Выход");

                Console.WriteLine("Чтобы перейти к нужному функционалу, введите нужную цифру");
                int commandNumber = ReadIntValue();

                switch (commandNumber)
                {
                    case (int)Commands.AddDossier:
                        TryAddDossier(dossiers);
                        break;

                    case (int)Commands.ShowAllDossiers:
                        ShowAllDossiers(dossiers);
                        break;

                    case (int)Commands.DeleteDossier:
                        DeleteDossier(dossiers);
                        break;

                    case (int)Commands.Exit:
                        isProgramWork = false;
                        break;

                    default:
                        Console.WriteLine("Недоступная команда");
                        break;
                }
            }
        }

        private static bool TryAddDossier(Dictionary<string, string> dossiers)
        {
            ReadData(out string fullName, out string position);

            if (dossiers.ContainsKey(fullName) == false)
            {
                dossiers.Add(fullName, position);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Досье добавлено");
                Console.ResetColor();

                return true;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Досье уже существует");
            Console.ResetColor();

            return false;
        }

        private static void ReadData(out string fullName, out string position)
        {
            fullName = null;
            position = null;

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

        private static void ShowAllDossiers(Dictionary<string, string> dossiers)
        {
            if (dossiers.Count == 0)
            {
                Console.WriteLine("Ни одно досье пока не добавлено");
            }
            else
            {
                foreach (var dossier in dossiers)
                {
                    Console.WriteLine($"ФИО: {dossier.Key}  позиция: {dossier.Value}");
                }

                Console.WriteLine();
            }
        }

        private static void DeleteDossier(Dictionary<string, string> dossiers)
        {
            if (dossiers.Count == 0)
            {
                Console.WriteLine("Ни одно досье пока не добавлено");
            }
            else
            {
                Console.WriteLine($"В системе зарегистрировано {dossiers.Count} досье");

                Console.WriteLine("Укажите ФИО из досье, которое желаете удалить");
                string fullname = Console.ReadLine();

                if (dossiers.ContainsKey(fullname))
                {
                    dossiers.Remove(fullname);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Досье удалено");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Досье с такими данными не найдено");
                }
            }
        }

        private static int ReadIntValue()
        {
            int value = 0;
            bool isIntValue = false;

            while (isIntValue == false)
            {
                string userInput = Console.ReadLine();
                isIntValue = int.TryParse(userInput, out value);

                if (isIntValue == false)
                {
                    Console.WriteLine("Можно вводить только числа");
                }
            }

            return value;
        }
    }

    public enum Commands : byte
    {
        AddDossier = 1,
        ShowAllDossiers,
        DeleteDossier,
        Exit
    }
}