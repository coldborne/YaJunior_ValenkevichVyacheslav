using System;
using System.Collections.Generic;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> employees = new Dictionary<string, string>()
            {
                {"Валенкевич Вячеслав Леонидович", "Тестировщик"},
                {"Греков грек Грекович", "Тестировщик"},
                {"Алексей Полный Алексеевич", "Менеджер"},
                {"Пирожок с маслом", "Аналитик"},
                {"Вкусное пироженое", "Программист"},
            };

            Console.Write("Введите ФИО сотрудника, профессию которого хотите определить: ");
            string word = Console.ReadLine();

            if (TryFindEmployee(employees, word, out string profession))
            {
                Console.WriteLine(profession);
            }
            else
            {
                Console.WriteLine("Такого сотрудника нет");
            }
        }

        private static bool TryFindEmployee(Dictionary<string, string> employees, string employee, out string profession)
        {
            profession = string.Empty;
            
            if (employees.ContainsKey(employee))
            {
                profession = employees[employee];
                
                return true;
            }

            return false;
        }
    }
}
