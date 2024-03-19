using System;
using System.Collections.Generic;

namespace Shop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int merchandiseQuantity = 10;

            MerchandiseCreator merchandiseCreator = new MerchandiseCreator();

            List<Merchandise> merchandises = merchandiseCreator.CreateUniqueMerchandiseList(merchandiseQuantity);
            Dictionary<Guid, Merchandise> inventory = new Dictionary<Guid, Merchandise>();

            foreach (Merchandise merchandise in merchandises)
            {
                inventory.Add(merchandise.Product.Id, merchandise);
            }

            int customerMoney = 150;
            Customer customer = new Customer(customerMoney);

            int sellerMoney = 150;
            Seller seller = new Seller(sellerMoney, inventory);

            Shop shop = new Shop(customer, seller);

            shop.Open();
        }
    }
}