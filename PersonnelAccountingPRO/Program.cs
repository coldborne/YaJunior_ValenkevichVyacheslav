using System;
using System.Collections.Generic;

namespace PersonnelAccountingPRO
{
    internal class Program
    {
        private static Dictionary<string, string> dossiers = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            bool isProgramWork = true;

            Console.WriteLine("Добро пожаловать в нашу секретную библиотеку!\nУ нас можно:");

            while (isProgramWork)
            {
                Console.WriteLine("1 - Добавить досье, 2 - Вывести все досье, 3 - Удалить одно досье, 4 - Выход");
                Console.WriteLine("Чтобы перейти к нужному функционалу, введите нужную цифру");
                int commandNumber = ReadIntValue();

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
                        break;
                }
            }
        }

        private static void AddDossier()
        {
            string fullName = null;
            string position = null;

            ReadData(ref fullName, ref position);

            dossiers.Add(fullName, position);

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

        private static void ShowAllDossiers()
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

        private static void DeleteDossier()
        {
            Console.WriteLine($"В системе зарегистрировано {dossiers.Count} досье. Укажите ФИО из досье, которое желаете удалить");

            string fullname = Console.ReadLine();

            if (dossiers.ContainsKey(fullname))
            {
                dossiers.Remove(fullname);
            }
            else
            {
                Console.WriteLine("Досье с такими данными не найдено");
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

        private static bool IsContainsFullData(string fullName)
        {
            string[] words = fullName.Split(' ');
            int minimumAmountWords = 2;
            int maximumAmountWords = 3;

            return words.Length >= minimumAmountWords && words.Length <= maximumAmountWords;
        }
    }
}
