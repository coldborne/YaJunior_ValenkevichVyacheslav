using System;
using System.Collections.Generic;

namespace Shop
{
    public static class DictionaryExtension
    {
        public static void Add(this Dictionary<Guid, Merchandise> merchandises, Merchandise merchandise)
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

        public static void Remove(this Dictionary<Guid, Merchandise> merchandises, Guid productId, int quantity)
        {
            if (merchandises.ContainsKey(productId))
            {
                Merchandise merchandise = merchandises[productId];

                if (merchandise.Quantity > quantity)
                {
                    throw new ArgumentException(
                        $"Попытка удаления бОльшего количества товара с id - {productId}, " +
                        $"количество товара {merchandise.Quantity}, попытались удалить {quantity}");
                }

                if (merchandise.Quantity == quantity)
                {
                    merchandises.Remove(productId);
                }
                else
                {
                    merchandise.DecreaseQuantity(quantity);
                }
            }
            else
            {
                throw new ArgumentException($"Попытка удаления несуществующего в списке товара с id - {productId}");
            }
        }
    }
}