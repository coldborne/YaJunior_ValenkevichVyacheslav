using System;
using System.Collections.Generic;
using Supermarket.Entities;

namespace Supermarket
{
    public class Supermarket
    {
        private List<Product> _storage;
        private Wallet _wallet;

        public Supermarket(List<Product> storage, Wallet wallet)
        {
            _storage = storage;
            _wallet = wallet;
        }

        public void Work(Queue<Customer> customers)
        {
            while (customers.Count > 0)
            {
                Customer customer = customers.Dequeue();

                Serve(customer);
            }

            Console.WriteLine($"Все клиенты обслужены, денег в магазине {_wallet.Balance}");
        }

        private void Serve(Customer customer)
        {
            Console.WriteLine($"Обслуживается покупатель - {customer}");
            Console.WriteLine("Список доступных продуктов:");
            ShowProductsInStorage();

            TakeProductsInBasket(customer);

            Console.WriteLine("Вы перемещаетесь к кассе");
            Console.WriteLine("Продукты в вашей корзине:");
            ShowProductsInBasket(customer);

            SellProducts(customer);
        }

        private void TakeProductsInBasket(Customer customer)
        {
            bool isReadyGoToCheckout = false;
            const int ProductSelectionPoint = 1;
            const int CheckoutPoint = 2;

            while (isReadyGoToCheckout == false)
            {
                Console.WriteLine("Выберите, номер продукта, который хотите взять");

                int userProductNumber = GetProductNumber();
                int userProductIndex = userProductNumber - 1;

                Product choisenProduct = _storage[userProductIndex].Copy();
                customer.AddInBasket(choisenProduct);
                Console.WriteLine($"Вы успешно положили продукт \"{choisenProduct}\" в корзину");

                Console.WriteLine("Хотите пойти на кассу или продолжить выбор?");
                Console.WriteLine($"{ProductSelectionPoint} - Продолжить выбор");
                Console.WriteLine($"{CheckoutPoint} - Пойти на кассу");

                bool isChoiceCorrect = false;
                int userPoint = 0;

                while (isChoiceCorrect == false)
                {
                    isChoiceCorrect = int.TryParse(Console.ReadLine(), out userPoint);

                    if (userPoint != ProductSelectionPoint && userPoint != CheckoutPoint)
                    {
                        isChoiceCorrect = false;
                        Console.WriteLine("Неверный пункт меню");
                    }
                }

                if (userPoint == CheckoutPoint)
                {
                    isReadyGoToCheckout = true;
                }
            }
        }

        private void SellProducts(Customer customer)
        {
            List<Product> customerProducts = customer.GetProductFromBasket();

            if (customerProducts.Count > 0)
            {
                int totalPrice = CalculateTotalBasketPrice(customer);
                Console.WriteLine($"Вы набрали продуктов на сумму - {totalPrice}");

                int customerMoneyAmount = customer.MoneyAmount;

                if (totalPrice > customerMoneyAmount)
                {
                    Console.WriteLine("У вас недостаточно денег, давайте вытаскивать продукты, пока денег не хватит");

                    while (totalPrice > customerMoneyAmount)
                    {
                        customer.TryRemoveRandomProductFromBasket();
                        totalPrice = CalculateTotalBasketPrice(customer);
                        Console.WriteLine("Вытащили продукт");
                    }
                }

                if (totalPrice > 0)
                {
                    customer.TryTakeMoney(totalPrice);
                    _wallet.Deposit(totalPrice);

                    List<Product> finalProducts = customer.GetProductFromBasket();

                    foreach (Product product in finalProducts)
                    {
                        customer.AddInBackpack(product);
                    }

                    customer.EmptyBasket();

                    Console.WriteLine("Вы успешно оплатили корзину, всего доброго!");
                }
                else
                {
                    Console.WriteLine("В вашей корзине не осталось товаров, извините, сегодня без покупок)");
                }
            }
            else
            {
                Console.WriteLine("Вы не выбрали ни одного продукта, приходите еще!");
            }
        }

        private int CalculateTotalBasketPrice(Customer customer)
        {
            List<Product> customerProducts = customer.GetProductFromBasket();

            if (customerProducts.Count > 0)
            {
                int totalPrice = 0;

                foreach (Product product in customerProducts)
                {
                    totalPrice += product.Price;
                }

                return totalPrice;
            }

            return 0;
        }

        private int GetProductNumber()
        {
            bool canParse = false;
            int userProductNumber = 0;
            bool isProductNumberCorrect = false;
            int minProductNumber = 0;
            int maxProductNumber = _storage.Count;

            while (isProductNumberCorrect == false)
            {
                while (canParse == false)
                {
                    string userInput = Console.ReadLine();
                    canParse = int.TryParse(userInput, out userProductNumber);

                    if (canParse == false)
                    {
                        Console.WriteLine("Неверный ввод");
                    }
                }

                if (userProductNumber >= minProductNumber && userProductNumber <= maxProductNumber)
                {
                    isProductNumberCorrect = true;
                }
                else
                {
                    Console.WriteLine("Продукта под таким номером нет на складе");
                }
            }

            return userProductNumber;
        }

        private void ShowProductsInStorage()
        {
            if (_storage.Count > 0)
            {
                int productCount = _storage.Count;

                for (int productIndex = 0; productIndex < productCount; productIndex++)
                {
                    int productNumber = productIndex + 1;
                    Console.Write($"{productNumber} - ");
                    var product = _storage[productIndex];
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("Склад пустой");
            }
        }

        private void ShowProductsInBasket(Customer customer)
        {
            List<Product> basketProducts = customer.GetProductFromBasket();

            if (basketProducts.Count > 0)
            {
                foreach (Product product in basketProducts)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("Корзина пуста");
            }
        }
    }
}