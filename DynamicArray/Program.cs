using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    internal class Program
    {
        const string Sum = "sum";
        const string Exit = "exit";

        static int[] numbers;

        static void Main(string[] args)
        {
            numbers = new int[0];

            bool isInputExit = false;

            while (isInputExit == false)
            {
                Console.WriteLine("sum - Сумма всех введенных чисел, exit - Выход из программы\n");

                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case Sum:
                        SumOfNumbers();
                        break;
                    case Exit:
                        isInputExit = true;
                        break;
                    default:
                        if (CheckVariableIsNumber(userInput) == true)
                        {
                            AddNumberInArray(userInput);
                        }
                        break;
                }

                Console.Clear();
            }
        }

        private static void SumOfNumbers()
        {
            if (numbers != null)
            {
                int sumOfNumbers = numbers[0];

                for (int i = 0; i < numbers.Length; i++)
                {
                    sumOfNumbers += numbers[i];
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

        private static void AddNumberInArray(string userInput)
        {
            int newNumber = int.Parse(userInput);
        }
    }
}
