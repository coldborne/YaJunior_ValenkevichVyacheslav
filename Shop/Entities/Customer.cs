using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Providers;

namespace Shop
{
    public class Customer : Person
    {
        private StealChance _stealChance;
        private RandomValueProvider _randomValueProvider;

        private Dictionary<Guid, Merchandise> _stolenMerchandises;

        public Customer(int money) : base(money)
        {
            _stealChance = new StealChance();
            _randomValueProvider = new RandomValueProvider();

            _stolenMerchandises = new Dictionary<Guid, Merchandise>();
        }

        public Customer(int money, Dictionary<Guid, Merchandise> merchandises) : base(money, merchandises)
        {
            _stealChance = new StealChance();
            _randomValueProvider = new RandomValueProvider();

            _stolenMerchandises = new Dictionary<Guid, Merchandise>();
        }

        public bool TryBuyMerchandise(Merchandise merchandise, int quantity)
        {
            if (CanBuy(merchandise, quantity) == false)
            {
                return false;
            }

            Add(merchandise);

            return true;
        }

        public bool TryStealMerchandise(Merchandise merchandise)
        {
            int stealSuccessThreshold = StealChance.MaxStealChance - _stealChance.Value;

            int stealAttempt =
                _randomValueProvider.GetRandomValue(StealChance.MinStealChance, StealChance.MaxStealChance);

            if (stealAttempt >= stealSuccessThreshold)
            {
                _stolenMerchandises.Increase(merchandise);

                return true;
            }

            return false;
        }

        public List<Merchandise> GetStolenMerchandises()
        {
            return _stolenMerchandises.Values.ToList().DeepCopy();
        }

        private bool CanBuy(Merchandise merchandise, int quantity)
        {
            int merchandisePrice = merchandise.Price;
            int totalPrice = merchandisePrice * quantity;

            return totalPrice <= Money;
        }
    }
}