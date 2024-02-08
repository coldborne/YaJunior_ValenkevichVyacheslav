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

            _inventory.Add(merchandise.Product.Id, merchandise);
        }

        public List<Merchandise> GetAllMerchandises()
        {
            List<Merchandise> merchandises = _inventory.Copy().Values.ToList();

            return merchandises;
        }

        public List<Merchandise> GetMerchandisesExpiredBefore(DateTime date)
        {
            return _inventory.Values
                .Where(merchandise => merchandise.Product.ExpirationDate < date)
                .ToList().DeepCopy();
        }

        public List<Merchandise> GetMerchandisesBy(Category category)
        {
            return _inventory.Values.Where(merchandise => merchandise.Categories.Contains(category)).ToList()
                .DeepCopy();
        }

        public List<Merchandise> GetMerchandisesBy(string name)
        {
            return _inventory.Values.Where(merchandise => merchandise.Product.Name == name).ToList()
                .DeepCopy();
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

            if (merchandise.Quantity == quantity)
            {
                _inventory.Remove(merchandise.Product.Id);
            }
            else
            {
                merchandise.DecreaseQuantity(quantity);
            }

            return true;
        }
    }
}