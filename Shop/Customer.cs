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

        public void PutMerchandiseInBasket(Merchandise merchandise)
        {
            _merchandisesInBasket.Add(merchandise);
        }

        public bool CanBuyMerchandiseInBasket()
        {
            return TotalBasketPrice <= _money;
        }

        public void TakeMoney(int money)
        {
            _money -= money;
        }
    }
}