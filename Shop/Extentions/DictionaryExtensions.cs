using System;
using System.Collections.Generic;

namespace Shop
{
    public static class DictionaryExtensions
    {
        public static void Increase(this Dictionary<Guid, Merchandise> merchandises, Merchandise merchandise)
        {
            Guid id = merchandise.Product.Id;

            if (merchandises.ContainsKey(id))
            {
                merchandises[id].IncreaseQuantity(merchandise.Quantity);
            }
            else
            {
                merchandises.Add(merchandise.Product.Id, merchandise);
            }
        }

        public static bool TryDecrease(this Dictionary<Guid, Merchandise> merchandises, Guid productId, int quantity)
        {
            if (merchandises.ContainsKey(productId) == false)
            {
                throw new ArgumentException($"Попытка продажи несуществующего в списке товара с id - {productId}");
            }

            Merchandise merchandise = merchandises[productId];

            if (merchandise.Quantity < quantity)
            {
                return false;
            }

            if (merchandise.Quantity == quantity)
            {
                merchandises.Remove(productId);
            }
            else
            {
                merchandise.DecreaseQuantity(quantity);
            }

            return true;
        }

        public static Dictionary<Guid, Merchandise> Copy(this Dictionary<Guid, Merchandise> merchandises)
        {
            Dictionary<Guid, Merchandise> copyMerchandises = new Dictionary<Guid, Merchandise>();

            foreach (var merchandiseEntry in merchandises)
            {
                copyMerchandises.Add(merchandiseEntry.Key, merchandiseEntry.Value.DeepCopy());
            }

            return copyMerchandises;
        }
    }
}