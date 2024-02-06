using System;
using System.Collections.Generic;

namespace Shop
{
    public class Shop
    {
        private Storage _storage;
        private UserUtils _userUtils;

        public Shop()
        {
            _storage = new Storage();
            _userUtils = new UserUtils();
        }

        public Shop(Storage storage)
        {
            _userUtils = new UserUtils();
            _storage = storage ?? throw new ArgumentException("Попытка добавления пустого склада в магазин");
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
                Console.WriteLine("3 - Выложить часть продуктов");
                Console.WriteLine("4 - Попытаться что-то украсть");
                Console.WriteLine("5 - Пойти на кассу для оплаты");

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
                        break;

                    case (int)Commands.Fourth:
                        isShopOpen = false;
                        break;

                    default:
                        Console.WriteLine("Такого Вы не умеете");
                        break;
                }
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

        private void Show(List<Merchandise> merchandises)
        {
            foreach (Merchandise merchandise in merchandises)
            {
                Console.WriteLine(merchandise.Info);
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
    }
}