using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop
{
    public abstract class Person
    {
        private Dictionary<Guid, Merchandise> _merchandises;

        public Person(int money)
        {
            int minimumMoneyAmount = 0;

            Money = money >= minimumMoneyAmount
                ? money
                : throw new ArgumentException("Попытка добавления отрицательного количества денег покупателю");

            _merchandises = new Dictionary<Guid, Merchandise>();
        }

        public Person(int money, Dictionary<Guid, Merchandise> merchandises)
        {
            int minimumMoneyAmount = 0;

            Money = money >= minimumMoneyAmount
                ? money
                : throw new ArgumentException("Попытка добавления отрицательного количества денег");

            _merchandises = merchandises ??
                            throw new ArgumentException(
                                "Попытка добавления пустого списка");
        }

        public int Money { get; private set; }

        protected void Add(Merchandise merchandise)
        {
            if (merchandise == null)
            {
                throw new ArgumentNullException("Попытка добавления пустого товара");
            }

            _merchandises.Increase(merchandise);
        }

        protected bool TryDecreaseMerchandiseQuantity(Guid productId, int quantity)
        {
            return _merchandises.TryDecrease(productId, quantity);
        }

        public bool CanTakeMerchandise(Guid productId, int quantity)
        {
            _merchandises.TryGetValue(productId, out Merchandise merchandise);

            if (merchandise == null)
            {
                throw new ArgumentException($"Попытка проверки несуществующего в списке товара с id - {productId}");
            }

            if (quantity <= 0)
            {
                return false;
            }

            return merchandise.Quantity >= quantity;
        }

        public void RemoveExpiredMerchandises(DateTime currentDate)
        {
            List<Guid> expiredMerchandisesGuids = new List<Guid>();

            foreach (var idMerchandisePair in _merchandises)
            {
                Merchandise merchandise = idMerchandisePair.Value;

                if (merchandise.Product.ExpirationDate < currentDate)
                {
                    expiredMerchandisesGuids.Add(merchandise.Product.Id);
                }
            }

            foreach (Guid expiredMerchandiseGuid in expiredMerchandisesGuids)
            {
                _merchandises.Remove(expiredMerchandiseGuid);
            }
        }

        public List<Merchandise> GetAllMerchandises()
        {
            List<Merchandise> merchandises = _merchandises.Copy().Values.ToList();

            return merchandises;
        }

        public List<Merchandise> GetMerchandisesBy(MerchandiseCategory merchandiseCategory)
        {
            List<Merchandise> merchandises = new List<Merchandise>();

            foreach (var idMerchandisePair in _merchandises)
            {
                Merchandise merchandise = idMerchandisePair.Value;

                if (merchandise.Categories.Contains(merchandiseCategory))
                {
                    merchandises.Add(merchandise.DeepCopy());
                }
            }

            return merchandises;
        }

        public List<Merchandise> GetMerchandisesBy(string name)
        {
            name = name.ToTitleCase();
            List<Merchandise> merchandises = new List<Merchandise>();

            foreach (var idMerchandisePair in _merchandises)
            {
                Merchandise merchandise = idMerchandisePair.Value;

                if (merchandise.Product.Name == name)
                {
                    merchandises.Add(merchandise.DeepCopy());
                }
            }

            return merchandises;
        }

        public bool TryIncreaseMoney(int money)
        {
            if (money <= 0)
            {
                return false;
            }

            Money += money;

            return true;
        }

        public bool TryDecreaseMoney(int money)
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
    }
}