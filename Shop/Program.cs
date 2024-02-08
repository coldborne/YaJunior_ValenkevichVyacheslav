using System;
using System.Collections.Generic;

namespace Shop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int merchandiseQuantity = 10;

            List<Merchandise> merchandises = MerchandiseCreator.CreateUniqueMerchandiseList(merchandiseQuantity);
            Dictionary<Guid, Merchandise> inventory = new Dictionary<Guid, Merchandise>();

            foreach (Merchandise merchandise in merchandises)
            {
                inventory.Add(merchandise.Product.Id, merchandise);
            }

            Storage storage = new Storage(inventory);

            Customer customer = new Customer(150);
            Shop shop = new Shop(customer, storage);

            shop.Open();
        }
    }
}