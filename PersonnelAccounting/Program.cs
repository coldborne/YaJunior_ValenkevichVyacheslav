using System;

namespace PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int AddDossierCommand = 1;
            const int ShowAllDossiersCommand = 2;
            const int DeleteDossierCommand = 3;
            const int SearchDossierByLastNameCommand = 4;
            const int ExitCommand = 5;

            string[] fullNames = new string[0];
            string[] positions = new string[0];

            bool isProgramWork = true;

            Console.WriteLine("Добро пожаловать в нашу секретную библиотеку!\nУ нас можно:");

            while (isProgramWork)
            {
                Console.WriteLine(
                    $"{AddDossierCommand} - Добавить досье, {ShowAllDossiersCommand} - Вывести все досье, {DeleteDossierCommand} - Удалить одно досье, {SearchDossierByLastNameCommand} - Поиск по фамилии, {ExitCommand} - Выход");
                Console.WriteLine("Чтобы перейти к нужному функционалу, введите нужную цифру");
                int commandNumber = ReadIntValue();

                switch (commandNumber)
                {
                    case AddDossierCommand:
                        AddDossier(ref fullNames, ref positions);
                        break;
                    case ShowAllDossiersCommand:
                        ShowAllDossiers(fullNames, positions);
                        break;
                    case DeleteDossierCommand:
                        DeleteDossier(ref fullNames, ref positions);
                        break;
                    case SearchDossierByLastNameCommand:
                        SearchDossierByLastName(fullNames, positions);
                        break;
                    case ExitCommand:
                        isProgramWork = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды у нас нет");
                        break;
                }
            }
        }

        private static void AddDossier(ref string[] fullNames, ref string[] positions)
        {
            ReadData(out string fullName, out string position);

            fullNames = Expand(fullNames);
            positions = Expand(positions);

            fullNames[fullNames.Length - 1] = fullName;
            positions[positions.Length - 1] = position;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Досье добавлено");
            Console.ResetColor();
        }

        private static void ReadData(out string fullName, out string position)
        {
            bool isFullNameCorrect = false;
            fullName = string.Empty;
            position = string.Empty;

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

        private static string[] Expand(string[] array)
        {
            string[] tempFullNames = new string[array.Length + 1];

            for(int i = 0; i < array.Length; i++)
            {
                tempFullNames[i] = array[i];
            }

            array = tempFullNames;

            return array;
        }

        private static void ShowAllDossiers(string[] fullNames, string[] positions)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("Ни одно досье пока не добавлено");
            }
            else
            {
                for(int i = 0; i < fullNames.Length - 1; i++)
                {
                    Console.Write($"{i + 1} - {fullNames[i]} {positions[i]} ");
                }

                Console.Write(
                    $"{fullNames.Length} - {fullNames[fullNames.Length - 1]} {positions[positions.Length - 1]} \n");
            }
        }

        private static void DeleteDossier(ref string[] fullNames, ref string[] positions)
        {
            Console.WriteLine(
                $"В системе зарегистрировано {fullNames.Length} досье. Укажите номер досье, которое желаете удалить");
            int numberOfDossier = ReadIntValue();
            int indexOfRemovedElement = numberOfDossier - 1;

            if (indexOfRemovedElement >= 0 && indexOfRemovedElement < fullNames.Length &&
                indexOfRemovedElement < positions.Length)
            {
                fullNames = Reduce(fullNames, indexOfRemovedElement);
                positions = Reduce(positions, indexOfRemovedElement);
            }
            else
            {
                Console.WriteLine("Досье под таким номером не найдено");
            }
        }

        private static string[] Reduce(string[] array, int indexOfRemovedElement)
        {
            string[] tempFullNames = new string[array.Length - 1];

            for(int i = 0; i < indexOfRemovedElement; i++)
            {
                tempFullNames[i] = array[i];
            }

            for(int i = indexOfRemovedElement + 1; i < array.Length; i++)
            {
                tempFullNames[i - 1] = array[i];
            }

            array = tempFullNames;

            return array;
        }

        private static void SearchDossierByLastName(string[] fullNames, string[] positions)
        {
            Console.WriteLine("Введите желаемую фамилию");
            string lastName = Console.ReadLine();

            bool wasDossierFound = false;

            for(int i = 0; i < fullNames.Length; i++)
            {
                if (lastName == fullNames[i].Split()[0])
                {
                    wasDossierFound = true;
                    Console.WriteLine(fullNames[i] + " " + positions[i]);
                }
            }

            if (wasDossierFound == false)
            {
                Console.WriteLine("Ничего не найдено");
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