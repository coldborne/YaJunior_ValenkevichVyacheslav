using System;

namespace SmallShop
{
    public class Shop
    {
        private enum Commands
        {
            ShowProducts = 1,
            MakeDeal,
            ShowCustomerProducts,
            Exit
        }

        private Customer _customer;
        private Seller _seller;

        public Shop(Customer customer, Seller seller)
        {
            _customer = customer;
            _seller = seller;
        }

        public void Work()
        {
            Console.WriteLine("Добро пожаловать в наш магазин");
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Выберите действие");

                Console.WriteLine(
                    $"{(int)Commands.ShowProducts} - Показать все товары магазина, " +
                    $"{(int)Commands.MakeDeal} - Купить товар, " +
                    $"{(int)Commands.ShowCustomerProducts} - Показать информацию о покупателе, " +
                    $"{(int)Commands.Exit} - Выйти из магазина");

                bool isInputValid = false;

                Commands command = 0;

                while (isInputValid == false)
                {
                    String userInput = Console.ReadLine();
                    isInputValid = Int32.TryParse(userInput, out int result);

                    command = (Commands)result;

                    if (isInputValid == false)
                    {
                        Console.WriteLine("Недопустимая команда");
                    }
                }

                switch (command)
                {
                    case Commands.ShowProducts:
                        ShowAllProducts();
                        break;
                    case Commands.MakeDeal:
                        MakeDeal();
                        break;
                    case Commands.ShowCustomerProducts:
                        ShowCustomerInfo();
                        break;
                    case Commands.Exit:
                        isWork = false;
                        break;
                }
            }
        }

        private void ShowAllProducts()
        {
            Console.WriteLine("Товары:");
            Console.WriteLine(_seller.GetProductsInfo());
        }

        private void MakeDeal()
        {
            Console.WriteLine("Введите название товара, который хотите купить");

            string productName = Console.ReadLine().Trim().ToLower();

            if (_seller.TryGetProduct(productName, out Product product))
            {
                if (_customer.TryBuyProduct(product))
                {
                    _seller.SellProduct(product);

                    Console.WriteLine("Продукт куплен");
                }
                else
                {
                    Console.WriteLine("Не удалось купить товар ");
                }
            }
            else
            {
                Console.WriteLine("Продукт с таким названием не найден");
            }
        }

        private void ShowCustomerInfo()
        {
            Console.WriteLine($"Денег в кошельке - {_customer.Money}, Доступный вес - {_customer.FreeWeight}");

            if (_customer.GetProductsInfo().Length > 0)
            {
                Console.WriteLine("Продукты:");
                Console.WriteLine(_customer.GetProductsInfo());
            }
            else
            {
                Console.WriteLine("Продуктов не куплено, желаем приятных покупок!");
            }
        }
    }
}