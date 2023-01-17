using System;

namespace SmallShop
{
    public class Shop
    {
        private enum Commands
        {
            ShowProducts,
            Exit
        }

        private Customer _customer;
        private Storage _storage;

        public Shop()
        {
            _customer = new Customer();
            _storage = new Storage();
        }

        public void Work()
        {
            Console.WriteLine("Добро пожаловать в наш магазин");

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1 - ");
                isWork = false;
            }
        }
    }
}