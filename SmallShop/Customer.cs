using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallShop
{
    public class Customer
    {
        private int _money;
        private List<Product> _products;
        private int _avaibleWeigth;

        public Customer()
        {
            _products = new List<Product>();
            _avaibleWeigth = 50;
        }

        public void ShowProducts()
        {
            foreach (Product product in _products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public bool TryBuyProduct(Product product)
        {
            if (product == null || product.Price > _money || product.Weight > _avaibleWeigth - _products.Sum(productInBag => productInBag.Weight))
            {
                return false;
            }

            _products.Add(product);
            _money -= product.Price;

            return true;
        }
    }
}