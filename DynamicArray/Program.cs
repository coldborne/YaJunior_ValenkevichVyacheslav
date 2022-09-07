using System;

namespace DynamicArray
{
    internal class Program
    {
        public const string Sum = "sum";
        public const string Exit = "exit";

        private static int[] _numbers;

        static void Main(string[] args)
        {
            int startSize = 0;
            _numbers = new int[startSize];

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
            if (_numbers != null & _numbers.Length != 0)
            {
                int sumOfNumbers = _numbers[0];

                for (int i = 1; i < _numbers.Length; i++)
                {
                    sumOfNumbers += _numbers[i];
                }

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

            ExpandArray();

            _numbers[_numbers.Length - 1] = newNumber;
        }

        private static void ExpandArray()
        {
            int[] tempNumbers = new int[_numbers.Length + 1];

            for (int i = 0; i < _numbers.Length; i++)
            {
                tempNumbers[i] = _numbers[i];
            }

            _numbers = tempNumbers;
        }
    }
}
