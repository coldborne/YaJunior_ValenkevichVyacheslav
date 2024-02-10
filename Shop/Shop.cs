using System;
using System.Collections.Generic;

namespace Shop
{
    public class Shop
    {
        private Storage _storage;
        private Customer _customer;
        private UserUtils _userUtils;

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
                Console.WriteLine("1 - Посмотреть все товары");
                Console.WriteLine("2 - Посмотреть продукты определенной категории");
                Console.WriteLine("3 - Выбрать товар и положить в корзину");
                Console.WriteLine("4 - Выложить часть продуктов");
                Console.WriteLine("5 - Попытаться что-то украсть");
                Console.WriteLine("6 - Пойти на кассу для оплаты");
                Console.WriteLine("7 - Завершить программу");

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

                        break;

                    case (int)Commands.Six:

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
            string[] categories = Enum.GetNames(typeof(Category));
            Console.WriteLine("Выберите категорию товара:");

            foreach (string currentCategory in categories)
            {
                Console.WriteLine(currentCategory);
            }

            bool canGetCategory = Enum.TryParse(Console.ReadLine(), out Category category);

            if (canGetCategory)
            {
                Show(_storage.GetMerchandisesBy(category));
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
            Merchandise merchandise = null;

            if (merchandises.Count < 1)
            {
                Console.WriteLine("Товар не найден");
            }
            else
            {
                if (merchandises.Count > 1)
                {
                    Console.WriteLine("Найдено несколько товаров с таким названием, выберите один:");

                    for(int i = 0; i < merchandises.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {merchandises[i].Info}");
                    }

                    int serialNumber = _userUtils.ReadInt() - 1;

                    if (serialNumber >= 0 && serialNumber < merchandises.Count)
                    {
                        merchandise = merchandises[serialNumber];
                    }
                }
                else
                {
                    merchandise = merchandises[0];
                }

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
                List<Merchandise> merchandisesOfCustomer = _customer.GetAllMerchandises();

                Console.WriteLine("Товары в вашей корзине:");

                foreach (Merchandise merchandiseByCustomer in merchandisesOfCustomer)
                {
                    Console.WriteLine(merchandiseByCustomer.Info);
                }

                string nameProduct = GetNameProduct();

                List<Merchandise> merchandises = _customer.GetMerchandisesBy(nameProduct);
                Merchandise merchandise = null;

                if (merchandises.Count < 1)
                {
                    Console.WriteLine("Такого товара нет в вашей корзине");
                }
                else
                {
                    if (merchandises.Count > 1)
                    {
                        Console.WriteLine("Найдено несколько товаров с таким названием, выберите один:");

                        for(int i = 0; i < merchandises.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {merchandises[i].Info}");
                        }

                        int serialNumber = _userUtils.ReadInt() - 1;

                        if (serialNumber > 0 && serialNumber < merchandises.Count)
                        {
                            merchandise = merchandises[serialNumber];
                        }
                    }
                    else
                    {
                        merchandise = merchandises[0];
                    }

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

        private void GoToCashier()
        {
            if (_customer.CanBuyMerchandiseInBasket())
            {
                _customer.TakeMoney(_customer.TotalBasketPrice);
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