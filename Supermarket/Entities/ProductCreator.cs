using System;
using System.Collections.Generic;

namespace Supermarket.Entities
{
    public class ProductCreator
    {
        private static int[] _prices = new int[] { 10, 50, 100, 1000 };
        private static string[] _names = new string[] { "Яблоко", "Груша", "Молочный шоколад", "Coca-cola" };
        private static Random _random = new Random();

        public Product Create()
        {
            int startPriceIndex = 0;
            int endPriceIndex = _prices.Length - 1;
            int priceIndex = _random.Next(startPriceIndex, endPriceIndex + 1);
            int price = _prices[priceIndex];

            int startNameIndex = 0;
            int endNameIndex = _names.Length - 1;
            int nameIndex = _random.Next(startNameIndex, endNameIndex + 1);
            string name = _names[nameIndex];

            Product product = new Product(name, price);

            return product;
        }

        public List<Product> Create(int count)
        {
            List<Product> products = new List<Product>();

            for (int i = 1; i <= count; i++)
            {
                Product product = Create();

                products.Add(product);
            }

            return products;
        }
    }
}