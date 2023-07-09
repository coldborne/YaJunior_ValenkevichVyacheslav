using System;

namespace SmallShop
{
    public class Provider
    {
        public Product GiveProduct()
        {
            return CreateProduct();
        }

        private Product CreateProduct()
        {
            String[] names = { "Конфеты", "Пирожки", "Молоко", "Сыр", "Котлеты" };
            int typesProductsAmount = names.Length;

            int minWeight = 10;
            int maxWeight = 20;

            int minPrice = 100;
            int maxPrice = 500;

            int weight = ProviderRandom.Random.Next(minWeight, maxWeight + 1);
            int price = ProviderRandom.Random.Next(minPrice, maxPrice + 1);
            string name = names[ProviderRandom.Random.Next(typesProductsAmount)];
            
            return new Product(name,weight,price);
        }
    }
}