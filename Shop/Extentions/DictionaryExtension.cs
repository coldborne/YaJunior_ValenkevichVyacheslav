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
    }
}