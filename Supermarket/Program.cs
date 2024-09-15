using System.Collections.Generic;
using Supermarket.Entities;

namespace Supermarket
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ProductCreator productCreator = new ProductCreator();
            List<Product> products = new List<Product>();

            int storeProductAmount = 10;

            for (int i = 1; i <= storeProductAmount; i++)
            {
                products.Add(productCreator.Create());
            }

            Supermarket supermarket = new Supermarket(products, new Wallet(0));
            Queue<Customer> customers = new Queue<Customer>();

            Customer firstCustomer = new Customer(new Wallet(200), "Вячеслейв");
            Customer secondCustomer = new Customer(new Wallet(5000), "Мишка");
            customers.Enqueue(firstCustomer);
            customers.Enqueue(secondCustomer);

            supermarket.Work(customers);
        }
    }
}