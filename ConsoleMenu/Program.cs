using System;

namespace ConsoleMenu
{
    internal class Program
    {
        private const string firstCommand = "PredictYearOfPurchaseApartment";
        private const string secondtCommand = "CompareNumbers";
        private const string thirdCommand = "ChangeConsoleSize";
        private const string fourthCommand = "Esc";

        private static bool _isExitCommandChosen = false;

        private static bool _isYearPredicted = false;
        private static int _predictedYearOfPurchaseApartment;

        static void Main(string[] args)
        {
            ListCommands();

            while (_isExitCommandChosen == false)
            {
                string chosenTeam = GetChosenCommand();
                ChooseCommand(chosenTeam);
            }
        }

        private static string GetChosenCommand()
        {
            return ReadStringValueFromKeyboard();
        }

        private static void ChooseCommand(string chosenTeam)
        {
            switch (chosenTeam)
            {
                case firstCommand:
                    PredictYearOfPurchaseApartment();
                    break;
                case secondtCommand:
                    CompareNumbers();
                    break;
                case thirdCommand:
                    ChangeConsoleSize();
                    break;
                case fourthCommand:
                    EndProgram();
                    break;
                default:
                    Console.WriteLine("Такое Мы не умеем, выберите что-то, что Мы можем");
                    break;
            }
        }

        private static string ReadStringValueFromKeyboard()
        {
            string valueFromKeyboard = Console.ReadLine().Trim();
            if (valueFromKeyboard == "")
            {
                Console.WriteLine("Программа не может состоять из пустой строки");
                return ReadStringValueFromKeyboard();
            }
            else
            {
                return valueFromKeyboard;
            }
        }

        private static int ReadIntValueFromKeyboard()
        {
            bool isIntValue = int.TryParse(Console.ReadLine(), out int value);

            if (isIntValue == true)
            {
                if (value <= 0)
                {
                    Console.WriteLine("Можно вводить только положительные числа");
                    return ReadIntValueFromKeyboard();
                }
                else
                {
                    return value;
                }
            }
            else
            {
                Console.WriteLine("Можно вводить только числа");
                return ReadIntValueFromKeyboard();
            }
        }

        private static void ListCommands()
        {
            Console.WriteLine("Наша программа умеет выполнять следующие команды:");
            Console.WriteLine($"{firstCommand} - предсказать год, когда Вы купите квартиру");
            Console.WriteLine($"{secondtCommand} - сравнить два числа");
            Console.WriteLine($"{thirdCommand} - изменить размер консоли");
            Console.WriteLine($"{fourthCommand} - выход из программы");
        }

        private static void PredictYearOfPurchaseApartment()
        {
            if (_isYearPredicted == false)
            {
                Random random = new Random();

                int currentYear = DateTime.Now.Year;

                _predictedYearOfPurchaseApartment = random.Next(currentYear, currentYear + 50);
                _isYearPredicted = true;
            }

            Console.WriteLine(_predictedYearOfPurchaseApartment);
        }

        private static void CompareNumbers()
        {
            Console.WriteLine("Введите первое число");
            int firstNumber = ReadIntValueFromKeyboard();
            Console.WriteLine("Введите второе число");
            int secondNumber = ReadIntValueFromKeyboard();

            if (firstNumber == secondNumber)
            {
                Console.WriteLine($"{firstNumber} = {secondNumber}");
            }
            else if (firstNumber > secondNumber)
            {
                Console.WriteLine($"{firstNumber} > {secondNumber}");
            }
            else
            {
                Console.WriteLine($"{firstNumber} < {secondNumber}");
            }
        }

        private static void ChangeConsoleSize()
        {
            int currentWidth = Console.WindowWidth;
            int currentHeight = Console.WindowHeight;

            Console.WriteLine("Текущий размер консоли: " + currentWidth + " " + currentHeight);
            Console.WriteLine("Изменить можно только на размер меньше, чем текущий");

            Console.WriteLine("Введите желаемую ширину консоли");
            int newConsoleWidth = ReadIntValueFromKeyboard();
            Console.WriteLine("Введите желаемую высоту консоли");
            int newConsoleheight = ReadIntValueFromKeyboard();

            if (newConsoleWidth > currentWidth || newConsoleheight > currentHeight)
            {
                Console.WriteLine("Невозможно поменять размер консоли на бОльший, чем текущий");
            }
            else
            {
                Console.SetWindowSize(newConsoleWidth, newConsoleheight);
            }
        }

        private static void EndProgram()
        {
            _isExitCommandChosen = true;
        }
    }
}