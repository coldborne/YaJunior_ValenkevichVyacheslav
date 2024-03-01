using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Providers;

namespace Shop
{
    public class Customer
    {
        private StealChance _stealChance;
        private RandomValueProvider _randomValueProvider;

        private Dictionary<Guid, Merchandise> _merchandisesInBasket;
        private Dictionary<Guid, Merchandise> _stolenMerchandises;
        private Dictionary<Guid, Merchandise> _backpack;

        public Customer(int money)
        {
            int minimumMoneyAmount = 0;

            Money = money >= minimumMoneyAmount
                ? money
                : throw new ArgumentException("Попытка добавления отрицательного количества денег покупателю");

            _stealChance = new StealChance();
            _randomValueProvider = new RandomValueProvider();

            _merchandisesInBasket = new Dictionary<Guid, Merchandise>();
            _stolenMerchandises = new Dictionary<Guid, Merchandise>();
            _backpack = new Dictionary<Guid, Merchandise>();
        }

        public int Money { get; private set; }
        public int TotalBasketPrice => _merchandisesInBasket.Values.Sum(merchandise => merchandise.Price);
        public int MerchandiseCountInBasket => _merchandisesInBasket.Count;
        public bool CanBuyMerchandiseInBasket => TotalBasketPrice <= Money;

        public void PutMerchandiseInBasket(Merchandise merchandise)
        {
            _merchandisesInBasket.Add(merchandise);
        }

        public void PutMerchandisesInBackpackFromBasket()
        {
            foreach (var idMerchandisePair in _merchandisesInBasket)
            {
                Merchandise merchandise = idMerchandisePair.Value;
                _backpack.Add(merchandise);
            }

            _merchandisesInBasket.Clear();
        }

        public bool TryStealMerchandise(Merchandise merchandise)
        {
            int stealSuccessThreshold = StealChance.MaxStealChance - _stealChance.Value;

            int stealAttempt =
                _randomValueProvider.GetRandomValue(StealChance.MinStealChance, StealChance.MaxStealChance);

            if (stealAttempt >= stealSuccessThreshold)
            {
                _stolenMerchandises.Add(merchandise);

                return true;
            }

            return false;
        }

        public bool TryTakeMerchandise(Guid productId, int quantity)
        {
            if (_merchandisesInBasket.ContainsKey(productId) == false)
            {
                return false;
            }

            Merchandise foundMerchandise = _merchandisesInBasket[productId];

            if (foundMerchandise.Quantity < quantity)
            {
                return false;
            }

            if (foundMerchandise.Quantity == quantity)
            {
                _merchandisesInBasket.Remove(productId);
            }
            else
            {
                foundMerchandise.DecreaseQuantity(quantity);
            }

            return true;
        }

        public bool TryTakeMoney(int money)
        {
            if (money <= 0)
            {
                return false;
            }

            if (Money < money)
            {
                return false;
            }

            Money -= money;
            return true;
        }

        public List<Merchandise> GetAllMerchandisesFromBasket()
        {
            return _merchandisesInBasket.Values.ToList().DeepCopy();
        }

        public List<Merchandise> GetMerchandisesFromBackpack()
        {
            return _backpack.Values.ToList().DeepCopy();
        }

        public List<Merchandise> GetStolenMerchandises()
        {
            return _stolenMerchandises.Values.ToList().DeepCopy();
        }

        public List<Merchandise> GetMerchandisesBy(string name)
        {
            List<Merchandise> merchandises = new List<Merchandise>();

            Merchandise merchandise;

            foreach (var idMerchandisePair in _merchandisesInBasket)
            {
                merchandise = idMerchandisePair.Value;

                if (merchandise.Product.Name == name)
                {
                    merchandises.Add(merchandise.Copy());
                }
            }

            return merchandises;
        }
    }
}