using System;
using System.Collections.Generic;

namespace Supermarket.Entities
{
    public class ProductCreator
    {
        private static int[] s_prices;
        private static string[] s_names;
        private static Random s_random;

        public ProductCreator()
        {
            s_prices = new int[] { 10, 50, 100, 1000 };
            s_names = new string[] { "Яблоко", "Груша", "Молочный шоколад", "Coca-cola" };
            s_random = new Random();
        }

        public Product Create()
        {
            int startPriceIndex = 0;
            int endPriceIndex = s_prices.Length - 1;
            int priceIndex = s_random.Next(startPriceIndex, endPriceIndex + 1);
            int price = s_prices[priceIndex];

            int startNameIndex = 0;
            int endNameIndex = s_names.Length - 1;
            int nameIndex = s_random.Next(startNameIndex, endNameIndex + 1);
            string name = s_names[nameIndex];

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