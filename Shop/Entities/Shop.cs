using System;
using System.Collections.Generic;
using System.Globalization;

namespace Shop
{
    public class Shop
    {
        private Storage _storage;
        private Customer _customer;
        private UserUtils _userUtils;
        private int _money;

        public Shop(Customer customer)
        {
            _storage = new Storage();
            _userUtils = new UserUtils();
            _customer = customer ?? throw new ArgumentException("Попытка добавления пустого покупателя в магазин");
        }

        public Shop(Customer customer, Storage storage)
        {
            _userUtils = new UserUtils();
            _storage = storage ?? throw new ArgumentException("Попытка добавления пустого склада в магазин");
            _customer = customer ?? throw new ArgumentException("Попытка добавления пустого покупателя в магазин");
        }

        public void Open()
        {
            bool isShopOpen = true;

            Console.WriteLine("Добро пожаловать в наш магазин");

            while (isShopOpen)
            {
                Console.WriteLine("Вы можете:");
                Console.WriteLine($"{(int)Commands.First} - Посмотреть все товары");
                Console.WriteLine($"{(int)Commands.Second} - Посмотреть продукты определенной категории");
                Console.WriteLine($"{(int)Commands.Third} - Выбрать товар и положить в корзину");
                Console.WriteLine($"{(int)Commands.Fourth} - Выложить часть продуктов");
                Console.WriteLine($"{(int)Commands.Five} - Попытаться что-то украсть");
                Console.WriteLine($"{(int)Commands.Six} - Пойти на кассу для оплаты");
                Console.WriteLine($"{(int)Commands.Seven} - Упасть без сознания");

                int command = _userUtils.ReadInt();

                switch (command)
                {
                    case (int)Commands.First:
                        Show(_storage.GetAllMerchandises().SortByMultipleCriteria());
                        break;

                    case (int)Commands.Second:
                        ApproachMerchandisesByCategory();
                        break;

                    case (int)Commands.Third:
                        TakeMerchandise();
                        break;

                    case (int)Commands.Fourth:
                        PlaceMerchandise();
                        break;

                    case (int)Commands.Five:
                        TryStealMerchandise();
                        break;

                    case (int)Commands.Six:
                        GoToCashier();
                        break;

                    case (int)Commands.Seven:
                        isShopOpen = false;
                        break;

                    default:
                        Console.WriteLine("Такого Вы не умеете");
                        break;
                }
            }
        }

        public void FillStorage(List<Merchandise> merchandises)
        {
            if (merchandises == null)
            {
                throw new ArgumentNullException("Попытка добавления пустого списка товаров в магазин");
            }

            foreach (Merchandise merchandise in merchandises)
            {
                _storage.Add(merchandise);
            }
        }

        private void Show(List<Merchandise> merchandises)
        {
            foreach (Merchandise merchandise in merchandises)
            {
                Console.WriteLine(merchandise.Info);
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

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            string userInput = Console.ReadLine()?.Trim().ToLower();
            string userSelectedCategory = string.Empty;

            if (userInput != null)
            {
                userSelectedCategory = textInfo.ToTitleCase(userInput);
            }

            bool canGetCategory = Enum.TryParse(userSelectedCategory, true, out MerchandiseCategory selectedCategory);

            if (canGetCategory)
            {
                Show(_storage.GetMerchandisesBy(selectedCategory));
            }
            else
            {
                Console.WriteLine("Данной категории нет в магазине");
            }
        }

        private void TakeMerchandise()
        {
            string nameProduct = GetNameProduct();

            List<Merchandise> merchandises = _storage.GetMerchandisesBy(nameProduct);
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

                bool canTakeMerchandise = _storage.TryTakeMerchandise(merchandise.Product.Id,
                    merchandiseCount);

                if (canTakeMerchandise)
                {
                    Merchandise merchandiseToCustomer = merchandise.Copy(merchandiseCount);

                    _customer.PutMerchandiseInBasket(merchandiseToCustomer);
                    Console.WriteLine("Вы успешно положили товар себе в корзину");
                }
                else
                {
                    Console.WriteLine("Такого количества товара нет на складе");
                }
            }
        }

        private void PlaceMerchandise()
        {
            if (_customer.MerchandiseCountInBasket > 0)
            {
                List<Merchandise> merchandisesOfCustomer = _customer.GetAllMerchandisesFromBasket();

                Console.WriteLine("Товары в вашей корзине:");
                Show(merchandisesOfCustomer);

                string nameProduct = GetNameProduct();

                List<Merchandise> merchandises = _customer.GetMerchandisesBy(nameProduct);
                int minimumMerchandiseCount = 1;

                if (merchandises.Count < minimumMerchandiseCount)
                {
                    Console.WriteLine("Такого товара нет в вашей корзине");
                }
                else
                {
                    Merchandise merchandise = SelectMerchandiseFromList(merchandises);

                    Console.WriteLine($"Вы выбрали {merchandise.Info}");
                    Console.WriteLine("Какое количество товара вы хотите положить?");

                    int merchandiseCount = _userUtils.ReadInt();

                    bool canTakeMerchandise = _customer.TryTakeMerchandise(merchandise.Product.Id,
                        merchandiseCount);

                    if (canTakeMerchandise)
                    {
                        Merchandise merchandiseToStorage = merchandise.Copy(merchandiseCount);

                        _storage.Add(merchandiseToStorage);
                        Console.WriteLine("Вы успешно положили товар обратно в магазин");
                    }
                    else
                    {
                        Console.WriteLine("Такого количества товара нет у вас в корзине");
                    }
                }
            }
            else
            {
                Console.WriteLine("В вашей корзине нет продуктов");
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

        private void TryStealMerchandise()
        {
            string nameProduct = GetNameProduct();

            List<Merchandise> merchandises = _storage.GetMerchandisesBy(nameProduct);

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

                bool canTakeMerchandise = _storage.TryTakeMerchandise(merchandise.Product.Id,
                    merchandiseCount);

                if (canTakeMerchandise)
                {
                    Merchandise stolenMerchandise = merchandise.Copy(merchandiseCount);

                    bool isSuccess = _customer.TryStealMerchandise(stolenMerchandise);

                    if (isSuccess)
                    {
                        Console.WriteLine("Вы успешно украли товар");
                    }
                    else
                    {
                        Console.WriteLine("Вам конец...");

                        _customer.TryTakeMoney(_customer.Money);
                        _money = _customer.Money;

                        Console.WriteLine($"У вас осталось {_customer.Money} деняк");
                    }
                }
                else
                {
                    Console.WriteLine("Такого количества товара нет на складе");
                }
            }

            List<Merchandise> stolenMerchandises = _customer.GetStolenMerchandises();
            Console.WriteLine("Ваши краденные вещи: ");

            foreach (Merchandise stolenMerchandise in stolenMerchandises)
            {
                Console.WriteLine(stolenMerchandise.Info);
            }
        }

        private void GoToCashier()
        {
            Console.WriteLine("Товары в вашей корзине:");
            Show(_customer.GetAllMerchandisesFromBasket());

            if (_customer.MerchandiseCountInBasket == 0)
            {
                Console.WriteLine("У вас нет товаров, можно ничего не оплачивать");
            }
            else if (_customer.CanBuyMerchandiseInBasket)
            {
                int basketPrice = _customer.TotalBasketPrice;
                _customer.TryTakeMoney(basketPrice);
                _customer.PutMerchandisesInBackpackFromBasket();
                _money += basketPrice;

                Console.WriteLine("Вы успешно купили товары, они добавлены вам в рюкзак");
                Console.WriteLine($"Магазин заработал на вас всего - {_money}");
            }
            else
            {
                Console.WriteLine($"Вы набрали товаров на {_customer.TotalBasketPrice}, у вас денег {_customer.Money}");
                Console.WriteLine("Цена ваших товаров больше, чем у вас есть денег. Выложите часть товаров");
            }

            List<Merchandise> backpack = _customer.GetMerchandisesFromBackpack();
            Console.WriteLine("Ваш рюкзак: ");

            foreach (Merchandise merchandise in backpack)
            {
                Console.WriteLine(merchandise.Info);
            }
        }

        private string GetNameProduct()
        {
            Console.WriteLine("Введите название товара, который вы хотите положить");
            string nameProduct = Console.ReadLine();

            return nameProduct;
        }
    }
}