using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop
{
    public class Storage
    {
        private Dictionary<Guid, Merchandise> _inventory;

        public Storage()
        {
            _inventory = new Dictionary<Guid, Merchandise>();
        }

        public Storage(Dictionary<Guid, Merchandise> inventory)
        {
            _inventory = inventory ??
                         throw new ArgumentNullException("Попытка добавления пустого списка товаров на склад");
        }

        public void Add(Merchandise merchandise)
        {
            if (merchandise == null)
            {
                throw new ArgumentNullException("Попытка добавления пустого товара на склад");
            }

            _inventory.Add(merchandise);
        }

        public List<Merchandise> GetAllMerchandises()
        {
            List<Merchandise> merchandises = _inventory.Copy().Values.ToList();

            return merchandises;
        }

        public List<Merchandise> GetMerchandisesExpiredBefore(DateTime date)
        {
            List<Merchandise> merchandises = new List<Merchandise>();

            foreach (var idMerchandisePair in _inventory)
            {
                Merchandise merchandise = idMerchandisePair.Value;

                if (merchandise.Product.ExpirationDate < date)
                {
                    merchandises.Add(merchandise.Copy());
                }
            }

            return merchandises;
        }

        public List<Merchandise> GetMerchandisesBy(MerchandiseCategory merchandiseCategory)
        {
            List<Merchandise> merchandises = new List<Merchandise>();

            foreach (var idMerchandisePair in _inventory)
            {
                Merchandise merchandise = idMerchandisePair.Value;

                if (merchandise.Categories.Contains(merchandiseCategory))
                {
                    merchandises.Add(merchandise.Copy());
                }
            }

            return merchandises;
        }

        public List<Merchandise> GetMerchandisesBy(string name)
        {
            List<Merchandise> merchandises = new List<Merchandise>();

            foreach (var idMerchandisePair in _inventory)
            {
                Merchandise merchandise = idMerchandisePair.Value;

                if (merchandise.Product.Name == name)
                {
                    merchandises.Add(merchandise.Copy());
                }
            }

            return merchandises;
        }

        public void RemoveExpiredMerchandise(DateTime currentDate)
        {
            List<Guid> expiredMerchandisesGuids = new List<Guid>();

            foreach (var idMerchandisePair in _inventory)
            {
                Merchandise merchandise = idMerchandisePair.Value;

                if (merchandise.Product.ExpirationDate < currentDate)
                {
                    expiredMerchandisesGuids.Add(merchandise.Product.Id);
                }
            }

            foreach (Guid expiredMerchandiseGuid in expiredMerchandisesGuids)
            {
                _inventory.Remove(expiredMerchandiseGuid);
            }
        }

        public bool TryTakeMerchandise(Guid productId, int quantity)
        {
            if (_inventory.TryGetValue(productId, out Merchandise merchandise) == false)
            {
                return false;
            }

            if (merchandise.Quantity < quantity)
            {
                return false;
            }

            _inventory.Remove(productId, quantity);

            return true;
        }
    }
}