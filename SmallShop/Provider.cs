using System.Collections.Generic;

namespace SmallShop
{
    public class Provider
    {
        private List<string> _names = new List<string>() { "конфеты", "пирожки", "молоко", "сыр", "котлеты" };

        public List<Product> GiveProducts()
        {
            List<Product> products = new List<Product>();

            foreach (string name in _names)
            {
                products.Add(CreateProduct(name));
            }

            return products;
        }

        private Product CreateProduct(string name)
        {
            int minWeight = 300;
            int maxWeight = 1500;

            int minPrice = 100;
            int maxPrice = 500;

            int weight = ProviderRandom.Random.Next(minWeight, maxWeight + 1);
            int price = ProviderRandom.Random.Next(minPrice, maxPrice + 1);

            return new Product(name, weight, price);
        }
    }
}