using System;

namespace DynamicArray
{
    internal class Program
    {
        const string Sum = "sum";
        const string Exit = "exit";

        static int[] _numbers;

        static void Main(string[] args)
        {
            int startSize = 0;
            _numbers = new int[startSize];

            bool isInputExit = false;

            while (isInputExit == false)
            {
                Console.Write("sum - Сумма всех введенных чисел, exit - Выход из программы\n");

                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case Sum:
                        SumOfnumbers();
                        break;
                    case Exit:
                        isInputExit = true;
                        break;
                    default:
                        if (CheckVariableIsNumber(userInput) == true)
                        {
                            AddNumber(userInput);
                        }
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void SumOfnumbers()
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

            int[] tempNumbers = new int[_numbers.Length + 1];

            for (int i = 0; i < _numbers.Length; i++)
            {
                tempNumbers[i] = _numbers[i];
            }

            tempNumbers[tempNumbers.Length - 1] = newNumber;

            _numbers = tempNumbers;
        }
    }
}
