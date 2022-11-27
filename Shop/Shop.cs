using System;
using System.Collections.Generic;

namespace Shop
{
    public class Shop
    {
        private Storage _storage;
        private List<Employee> _employees;

        public Shop()
        {
            _storage = new Storage();
            _employees = new List<Employee>();

            AddEmployeesToShift();
        }

        private void AddEmployeesToShift()
        {
            Console.WriteLine("Сколько сотрудников Вы хотите добавить?");
            int employeesAmount = UserUtils.ReadNumberOfEmployees();

            for (int i = 0; i < employeesAmount; i++)
            {
                _employees.Add(new Employee());
            }
        }

        public void ShowItemsInStorage()
        {
            _storage.ShowItems();
        }
        
        public Item TakeItemFromStorage()
        {
            var item = _storage.TakeItem();
            
            item = new Item(new Apple(10, 15), 10);

            return item;
        }
    }
}