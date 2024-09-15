using System;
using System.Collections.Generic;
using Supermarket.Entities;

namespace Supermarket
{
    public class Customer
    {
        private Wallet _wallet;
        private List<Product> _basket;
        private List<Product> _backpack;

        private Random _random;

        public Customer(Wallet wallet, string name)
        {
            _wallet = wallet;
            _basket = new List<Product>();
            _backpack = new List<Product>();
            _random = new Random();
            Name = name;
        }

        public int MoneyAmount => _wallet.Balance;
        public string Name { get; }

        public bool TryTakeMoney(int moneyAmount)
        {
            return _wallet.TryWithdraw(moneyAmount);
        }

        public void AddInBasket(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException("Передан пустой продукт при попытке положить его в корзину");
            }

            _basket.Add(product);
        }

        public bool TryRemoveRandomProductFromBasket()
        {
            const int MinProductAmount = 0;
            
            int productCount = _basket.Count;

            if (productCount > MinProductAmount)
            {
                int productIndex = _random.Next(productCount);
                _basket.RemoveAt(productIndex);

                return true;
            }

            return false;
        }

        public List<Product> GetProductFromBasket()
        {
            List<Product> products = new List<Product>();

            foreach (Product product in _basket)
            {
                products.Add(product.Copy());
            }

            return products;
        }

        public void ClearBasket()
        {
            _basket.Clear();
        }

        public void AddInBackpack(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException("Передан пустой продукт при попытке положить его в рюкзак");
            }

            _backpack.Add(product);
        }

        public override string ToString()
        {
            return $"Клиент: {Name}, Количество денег: {MoneyAmount}";
        }
    }
}