using System.Collections.Generic;

namespace SmallShop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Provider provider = new Provider();

            List<Product> products = provider.GiveProducts();

            Customer customer = new Customer();
            Seller seller = new Seller(products);
            Shop shop = new Shop(customer, seller);

            shop.Work();
        }
    }
}