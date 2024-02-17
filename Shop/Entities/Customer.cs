using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Providers;

namespace Shop
{
    public class Customer
    {
        private List<Merchandise> _merchandisesInBasket;
        private List<Merchandise> _stolenMerchandises;
        private List<Merchandise> _backpack;
        private StealChance _stealChance;

        public Customer(int money)
        {
            Money = money > 0
                ? money
                : throw new ArgumentException("Попытка добавления отрицательного количества денег покупателю");

            _merchandisesInBasket = new List<Merchandise>();
            _stolenMerchandises = new List<Merchandise>();
            _backpack = new List<Merchandise>();
            _stealChance = new StealChance();
        }

        public int Money { get; private set; }
        public int TotalBasketPrice => _merchandisesInBasket.Sum(merchandise => merchandise.Price);
        public int MerchandiseCountInBasket => _merchandisesInBasket.Count;

        public void PutMerchandiseInBasket(Merchandise merchandise)
        {
            _merchandisesInBasket.Add(merchandise);
        }

        public void PutMerchandiseInPocket(Merchandise merchandise)
        {
            _stolenMerchandises.Add(merchandise);
        }

        public void PutMerchandisesInBackpack()
        {
            _backpack = _merchandisesInBasket.DeepCopy();
            _merchandisesInBasket.Clear();
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

        public bool TryStealMerchandise(Merchandise merchandise)
        {
            int stealSuccessThreshold = StealChance.MaxStealChance - _stealChance.Value;

            int stealAttempt =
                RandomValueProvider.GetRandomValue(StealChance.MinStealChance, StealChance.MaxStealChance);

            if (stealAttempt >= stealSuccessThreshold)
            {
                PutMerchandiseInPocket(merchandise);

                return true;
            }

            return false;
        }

        public bool CanBuyMerchandiseInBasket()
        {
            return TotalBasketPrice <= Money;
        }

        public void TakeMoney(int money)
        {
            Money -= money;
        }

        public List<Merchandise> GetAllMerchandises()
        {
            return _merchandisesInBasket.DeepCopy();
        }

        public List<Merchandise> GetMerchandisesFromBackpack()
        {
            return _backpack.DeepCopy();
        }

        public List<Merchandise> GetStolenMerchandises()
        {
            return _stolenMerchandises.DeepCopy();
        }
    }
}