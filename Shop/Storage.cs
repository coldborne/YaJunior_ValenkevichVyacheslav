using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Enums;

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
            _inventory = inventory;
        }

        public void Add(Merchandise merchandise)
        {
            if (merchandise == null)
            {
                throw new ArgumentException("Попытка добавления пустого товара");
            }

            _inventory.Add(merchandise.Product.Id, merchandise);
        }

        public Dictionary<Guid, Merchandise> GetAllMerchandises()
        {
            Dictionary<Guid, Merchandise> merchandises = _inventory.Copy();

            return merchandises;
        }

        public List<Merchandise> GetMerchandisesExpiredBefore(DateTime date)
        {
            return _inventory.Values
                .Where(merchandise => merchandise.Product.ExpirationDate < date)
                .ToList().Copy();
        }

        public List<Merchandise> GetMerchandisesBy(Category category)
        {
            return _inventory.Values.Where(merchandise => merchandise.Category == category).ToList().Copy();
        }

        public void RemoveExpiredMerchandise(DateTime currentDate)
        {
            List<Guid> expiredMerchandisesGuids = _inventory
                .Where(pair => pair.Value.Product.ExpirationDate < currentDate)
                .Select(pair => pair.Key)
                .ToList();

            foreach (Guid expiredMerchandiseGuid in expiredMerchandisesGuids)
            {
                _inventory.Remove(expiredMerchandiseGuid);
            }
        }

        public bool TryTakeProduct(Guid productId, int quantity, out Product product)
        {
            product = null;

            if (_inventory.TryGetValue(productId, out Merchandise merchandise))
            {
                if (merchandise.Quantity >= quantity)
                {
                    merchandise.DecreaseQuantity(quantity);
                    product = merchandise.Product;

                    if (merchandise.Quantity == 0)
                    {
                        _inventory.Remove(productId);
                    }

                    return true;
                }
            }

            return false;
        }
    }
}