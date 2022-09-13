using System;
using System.Collections.Generic;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> employees = new Dictionary<int, string>();

            employees.Add(1, "Программист");
            employees.Add(2, "Тестировщик");
            employees.Add(3, "Менеджер");
            employees.Add(4, "Аналитик");
            employees.Add(5, "Программист");

            Console.Write("Введите сотрудника, которого хотите найти: ");
            string word = Console.ReadLine();

            if (employees.ContainsValue(word))
            {
                Console.WriteLine(word);
            }
            else
            {
                Console.WriteLine("Такого сотрудника нет");
            }
        }
    }
}
