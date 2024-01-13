using System;
using System.Collections;

namespace DynamicArrayPRO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Sum = "sum";
            const string Exit = "exit";
            
            ArrayList numbers = new ArrayList();

            bool isInputExit = false;

            while (isInputExit == false)
            {
                Console.Write($"{Sum} - Сумма всех введенных чисел, {Exit} - Выход из программы\n");

                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case Sum:
                        CalculateSumOfNumbers(numbers);
                        break;

                    case Exit:
                        isInputExit = true;
                        break;

                    default:
                        TryReadNumber(numbers, userInput);
                        break;
                }
            }
        }

        private static void CalculateSumOfNumbers(ArrayList numbers)
        {
            if (numbers != null & numbers.Count != 0)
            {
                int sumOfNumbers = 0;

                for(int i = 0; i < numbers.Count; i++)
                {
                    sumOfNumbers += (int)numbers[i];
                }

                Console.WriteLine(sumOfNumbers);
            }
            else
            {
                Console.WriteLine("Вы ещё не добавили ни одного числа");
            }
        }

        private static void TryReadNumber(ArrayList numbers, string userInput)
        {
            if (IsVariableNumber(userInput))
            {
                int newNumber = int.Parse(userInput);

                numbers.Add(newNumber);
            }
        }

        private static bool IsVariableNumber(string userInput)
        {
            bool isIntValue = int.TryParse(userInput, out int value);

            if (isIntValue == false)
            {
                Console.WriteLine("Добавлять можно только целые числа");
            }

            return isIntValue;
        }
    }
}