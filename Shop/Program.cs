using System;

namespace Shop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Shop shop = new Shop();

            bool isShopOpen = true;

            Console.WriteLine("Добро пожаловать в наш магазин");

            while (isShopOpen)
            {
                Console.WriteLine("Вы можете:");
                Console.WriteLine("1 - Выбрать продукты для покупки");
                Console.WriteLine("2 - Пойти на кассу для оплаты");
                Console.WriteLine("3 - Попытаться что-то украсть");
                Console.WriteLine("4 - Уйти из Магазина");

                int command = UserUtils.ReadInt();

                switch (command)
                {
                    case (int)Commands.First:
                        SelectProducts(shop);
                        break;
                    case (int)Commands.Second:
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

        private static void SelectProducts(Shop shop)
        {
            shop.ShowItemsInStorage();
        }
    }
}