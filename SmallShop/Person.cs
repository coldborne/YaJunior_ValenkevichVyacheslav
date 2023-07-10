using System;
using System.Collections.Generic;

namespace SmallShop
{
    public abstract class Person
    {
        protected List<Product> Products;
        
        public Person(int money)
        {
            Products = new List<Product>();
            Money = money;
        }
        
        public int Money { get; protected set; }

        public string GetProductsInfo()
        {
            return string.Join(Environment.NewLine, Products);
        }
    }
}