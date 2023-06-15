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

        private int FreeWeight => _avaibleWeigth - _products.Sum(productInBag => productInBag.Weight);

        public Customer()
        {
            _products = new List<Product>();
            _avaibleWeigth = 50;
            _money = 500;
        }
        
        public bool TryBuyProduct(Product product)
        {
            if ((IsFreeWeightEnough(product) || IsMoneyEnough(product)) == false)
            {
                return false;
            }

            _products.Add(product);
            _money -= product.Price;

            return true;
        }
        
        public override string ToString()
        {
            return string.Join(Environment.NewLine, _products);
        }
        
        private bool IsFreeWeightEnough(Product product)
        {
            return product.Weight <= FreeWeight;
        }
        
        private bool IsMoneyEnough(Product product)
        {
            return product.Price <= _money;
        }
    }
}