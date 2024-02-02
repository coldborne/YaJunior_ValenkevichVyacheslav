using System;
using System.Collections.Generic;

namespace Shop
{
    public static class DictionaryExtensions
    {
        public static Dictionary<Guid, Merchandise> Copy(this Dictionary<Guid, Merchandise> merchandises)
        {
            Dictionary<Guid, Merchandise> copyMerchandises = new Dictionary<Guid, Merchandise>();

            foreach (var merchandiseEntry in merchandises)
            {
                copyMerchandises.Add(merchandiseEntry.Key, merchandiseEntry.Value.Copy());
            }

            return copyMerchandises;
        }
    }
}