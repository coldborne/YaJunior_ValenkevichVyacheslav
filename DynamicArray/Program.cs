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
            if (IsVariableNumber(userInput, out int value))
            {
                AddNumber(value);
            }
        }

        private static bool IsVariableNumber(string userInput, out int number)
        {
            bool isIntValue = int.TryParse(userInput, out number);

            if (isIntValue == false)
            {
                Console.WriteLine("Добавлять можно только целые числа");
            }

            return isIntValue;
        }

        private static void AddNumber(int number)
        {
            ExpandArray();

            _numbers[_numbers.Length - 1] = number;
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
