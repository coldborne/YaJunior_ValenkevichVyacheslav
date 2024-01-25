using System;
using System.Collections.Generic;

namespace Shop
{
    public static class DictionaryExtensions
    {
        public static Dictionary<Guid, Item> Copy(this Dictionary<Guid, Item> items)
        {
            Dictionary<Guid, Item> copyItems = new Dictionary<Guid, Item>();

            foreach (var itemEntry in items)
            {
                copyItems.Add(itemEntry.Key, itemEntry.Value.Copy());
            }

            return copyItems;
        }
    }
}