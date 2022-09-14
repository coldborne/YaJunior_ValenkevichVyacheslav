using System;
using System.Collections;

namespace DynamicArrayPRO
{
    internal class Program
    {
        public const string Sum = "sum";
        public const string Exit = "exit";

        private static ArrayList _numbers;

        static void Main(string[] args)
        {
            _numbers = new ArrayList();

            bool isInputExit = false;

            while (isInputExit == false)
            {
                Console.Write($"{Sum} - Сумма всех введенных чисел, {Exit} - Выход из программы\n");

                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case Sum:
                        CalculateSumOfnumbers();
                        break;
                    case Exit:
                        isInputExit = true;
                        break;
                    default:
                        TryReadNumber(userInput);
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void CalculateSumOfnumbers()
        {
            if (_numbers != null & _numbers.Count != 0)
            {
                int sumOfNumbers = 0;

                for (int i = 0; i < _numbers.Count; sumOfNumbers += (int)_numbers[i], i++) ;

                Console.WriteLine(sumOfNumbers);
            }
            else
            {
                Console.WriteLine("Вы ещё не добавили ни одного числа");
            }
        }

        private static void TryReadNumber(string userInput)
        {
            if (CheckVariableIsNumber(userInput))
            {
                AddNumber(userInput);
            }
        }

        private static bool CheckVariableIsNumber(string userInput)
        {
            bool isIntValue = int.TryParse(userInput, out int value);

            if (isIntValue == false)
            {
                Console.WriteLine("Добавлять можно только целые числа");
            }

            return isIntValue;
        }

        private static void AddNumber(string userInput)
        {
            int newNumber = int.Parse(userInput);

            _numbers.Add(newNumber);
        }
    }
}
