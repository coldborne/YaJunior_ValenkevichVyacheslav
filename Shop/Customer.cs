using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop
{
    public class Customer
    {
        private int _money;
        private List<Merchandise> _merchandisesInBasket;

        public Customer(int money)
        {
            _money = money > 0
                ? money
                : throw new ArgumentException("Попытка добавления отрицательного количества денег покупателю");

            _merchandisesInBasket = new List<Merchandise>();
        }

        public int TotalBasketPrice => _merchandisesInBasket.Sum(merchandise => merchandise.Price);
        public int MerchandiseCountInBasket => _merchandisesInBasket.Count;

        public void PutMerchandiseInBasket(Merchandise merchandise)
        {
            _merchandisesInBasket.Add(merchandise);
        }

        public List<Merchandise> GetMerchandisesBy(string name)
        {
            return _merchandisesInBasket.Where(merchandise => merchandise.Product.Name == name).ToList()
                .DeepCopy();
        }

        public bool TryTakeMerchandise(Guid productId, int quantity)
        {
            if (_merchandisesInBasket.Any(merchandise => merchandise.Product.Id == productId) == false)
            {
                return false;
            }

            Merchandise foundMerchandise =
                _merchandisesInBasket.Find(requiredMerchandise => requiredMerchandise.Product.Id == productId);

            if (foundMerchandise.Quantity < quantity)
            {
                return false;
            }

            if (foundMerchandise.Quantity == quantity)
            {
                _merchandisesInBasket.Remove(foundMerchandise);
            }
            else
            {
                foundMerchandise.DecreaseQuantity(quantity);
            }

            return true;
        }

        public bool CanBuyMerchandiseInBasket()
        {
            return TotalBasketPrice <= _money;
        }

        public void TakeMoney(int money)
        {
            _money -= money;
        }

        public List<Merchandise> GetAllMerchandises()
        {
            return _merchandisesInBasket.DeepCopy();
        }
    }
}