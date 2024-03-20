using System;
using System.Collections.Generic;

namespace Shop
{
    public class Shop
    {
        private Seller _seller;
        private Customer _customer;
        private UserUtils _userUtils;
        private bool _isCustomerThief;

        public Shop(Customer customer, Seller seller)
        {
            _seller = seller ?? throw new ArgumentException("Попытка добавления пустого продавца в магазин");
            _customer = customer ?? throw new ArgumentException("Попытка добавления пустого покупателя в магазин");
            _userUtils = new UserUtils();
            _isCustomerThief = false;
        }

        public void Open()
        {
            bool isShopOpen = true;

            Console.WriteLine("Добро пожаловать в наш магазин");

            while (isShopOpen)
            {
                if (_isCustomerThief == false)
                {
                    Console.WriteLine("Вы можете:");
                    Console.WriteLine($"{(int)Commands.First} - Посмотреть все товары продавца");
                    Console.WriteLine($"{(int)Commands.Second} - Посмотреть товары продавца определенной категории");
                    Console.WriteLine($"{(int)Commands.Third} - Посмотреть все свои товары");
                    Console.WriteLine($"{(int)Commands.Fourth} - Купить товар");
                    Console.WriteLine($"{(int)Commands.Five} - Попытаться что-то украсть");
                    Console.WriteLine($"{(int)Commands.Six} - Пойти домой");

                    int command = _userUtils.ReadInt();

                    switch (command)
                    {
                        case (int)Commands.First:
                            Show(_seller.GetAllMerchandises().SortByMultipleCriteria());
                            break;

                        case (int)Commands.Second:
                            ApproachMerchandisesByCategory();
                            break;

                        case (int)Commands.Third:
                            Show(_customer.GetAllMerchandises().SortByMultipleCriteria());
                            break;

                        case (int)Commands.Fourth:
                            Trade();
                            break;

                        case (int)Commands.Five:
                            TryStealMerchandise();
                            break;

                        case (int)Commands.Six:
                            isShopOpen = false;
                            break;

                        default:
                            Console.WriteLine("Такого Вы не умеете");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Зря вы полезли своими грязными ручонками к нашему товару...");
                    isShopOpen = false;
                }
            }

            GoToCashier();
        }

        private void Show(List<Merchandise> merchandises)
        {
            if (merchandises.Count == 0)
            {
                Console.WriteLine("Показывать нечего");
            }
            else
            {
                foreach (Merchandise merchandise in merchandises)
                {
                    Console.WriteLine(merchandise.Info);
                }
            }
        }

        private void ApproachMerchandisesByCategory()
        {
            string[] categories = Enum.GetNames(typeof(MerchandiseCategory));
            Console.WriteLine("Выберите категорию товара:");

            foreach (string category in categories)
            {
                Console.WriteLine(category);
            }

            string userInput = Console.ReadLine()?.Trim().ToLower();
            string userSelectedCategory = userInput.ToTitleCase();

            bool canGetCategory = Enum.TryParse(userSelectedCategory, true, out MerchandiseCategory selectedCategory);

            if (canGetCategory)
            {
                Show(_seller.GetMerchandisesBy(selectedCategory));
            }
            else
            {
                Console.WriteLine("Данной категории нет в магазине");
            }
        }

        private void Trade()
        {
            string nameProduct = GetNameProduct();

            List<Merchandise> merchandises = _seller.GetMerchandisesBy(nameProduct);
            int minimumMerchandiseCount = 1;

            if (merchandises.Count < minimumMerchandiseCount)
            {
                Console.WriteLine("Товар не найден");
            }
            else
            {
                Merchandise merchandise = SelectMerchandiseFromList(merchandises);

                Console.WriteLine($"Вы выбрали {merchandise.Info}");
                Console.WriteLine("Какое количество товара вы хотите купить?");

                int merchandiseCount = _userUtils.ReadInt();

                bool canTakeMerchandise = _seller.CanTakeMerchandise(merchandise.Product.Id,
                    merchandiseCount);

                if (canTakeMerchandise)
                {
                    Merchandise merchandiseToSell = merchandise.DeepCopy(merchandiseCount);

                    bool canBuy = _customer.TryBuyMerchandise(merchandiseToSell, merchandiseToSell.Quantity);
                    int totalPrice = merchandiseToSell.Price * merchandiseToSell.Quantity;

                    if (canBuy)
                    {
                        _seller.TrySellMerchandise(merchandiseToSell.Product.Id, merchandiseToSell.Quantity);

                        _customer.TryDecreaseMoney(totalPrice);
                        _seller.TryIncreaseMoney(totalPrice);

                        Console.WriteLine($"Вы успешно купили товар на сумму {totalPrice}");
                    }
                    else
                    {
                        Console.WriteLine("Вы не можете купить товар");
                        Console.WriteLine($"Итоговая цена товара {totalPrice}, у вас деняк {_customer.Money}");
                    }
                }
                else
                {
                    Console.WriteLine(
                        $"Продавец не может продать товар - \"{merchandise.Product.Name} {merchandise.Product.GetDescription()}\", " +
                        $"количество товара {merchandise.Quantity}, попытались купить {merchandiseCount}");
                }
            }
        }

        private void TryStealMerchandise()
        {
            string nameProduct = GetNameProduct();

            List<Merchandise> merchandises = _seller.GetMerchandisesBy(nameProduct);

            if (merchandises.Count < 1)
            {
                Console.WriteLine("Товар не найден");
            }
            else
            {
                Merchandise merchandise = SelectMerchandiseFromList(merchandises);

                Console.WriteLine($"Вы выбрали {merchandise.Info}");
                Console.WriteLine("Какое количество товара вы хотите украсть?");

                int merchandiseCount = _userUtils.ReadInt();

                bool canTakeMerchandise = _seller.CanTakeMerchandise(merchandise.Product.Id,
                    merchandiseCount);

                if (canTakeMerchandise)
                {
                    Merchandise stolenMerchandise = merchandise.DeepCopy(merchandiseCount);

                    bool isSuccess = _customer.TryStealMerchandise(stolenMerchandise);

                    if (isSuccess)
                    {
                        _seller.TrySellMerchandise(merchandise.Product.Id,
                            stolenMerchandise.Quantity);

                        int totalPrice = stolenMerchandise.Price * stolenMerchandise.Quantity;
                        Console.WriteLine($"Вы успешно украли товар на сумму {totalPrice}");
                    }
                    else
                    {
                        Console.WriteLine("Вам конец...");
                        int money = _customer.Money;

                        _customer.TryDecreaseMoney(money);
                        _seller.TryIncreaseMoney(money);

                        Console.WriteLine($"У вас осталось {_customer.Money} деняк");
                        _isCustomerThief = true;
                    }
                }
                else
                {
                    Console.WriteLine(
                        $"Вы не можете украсть товар - {merchandise.Info}, " +
                        $"количество товара {merchandise.Quantity}, попытались украсть {merchandise.Quantity}");
                }
            }
        }

        private Merchandise SelectMerchandiseFromList(List<Merchandise> merchandises)
        {
            Merchandise merchandise = null;

            if (merchandises.Count > 1)
            {
                Console.WriteLine("Найдено несколько товаров с таким названием, выберите один:");

                for(int i = 0; i < merchandises.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {merchandises[i].Info}");
                }

                bool isSerialNumberValid = false;

                while (isSerialNumberValid == false)
                {
                    int serialNumber = _userUtils.ReadInt() - 1;

                    if (serialNumber >= 0 && serialNumber < merchandises.Count)
                    {
                        merchandise = merchandises[serialNumber];
                        isSerialNumberValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Товара с таким номером не найдено, попробуйте ещё раз!");
                    }
                }
            }
            else
            {
                merchandise = merchandises[0];
            }

            return merchandise;
        }

        private string GetNameProduct()
        {
            Console.WriteLine("Введите название товара, который вы хотите положить");
            string nameProduct = Console.ReadLine();

            return nameProduct;
        }

        private void GoToCashier()
        {
            Console.WriteLine("Товары в вашем рюкзаке:");
            Show(_customer.GetAllMerchandises());

            Console.WriteLine($"У вас денег - {_customer.Money}");

            Console.WriteLine("Украденные товар:");
            Show(_customer.GetStolenMerchandises());
        }
    }
}