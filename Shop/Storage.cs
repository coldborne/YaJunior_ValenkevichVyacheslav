using System;
using System.Collections.Generic;
using Shop.Enums;

namespace Shop
{
    public class Storage
    {
        private Dictionary<Guid, Item> _items;

        public Storage()
        {
            _items = new Dictionary<Guid, Item>();

            Item item1 = new Item(new Apple(1, "", Variety.Gala, Taste.Sour), 10, 50);
            Item item2 = new Item(new Candy(1, "", 0.5f), 10, 50);

            _items.Add(item1.ProductId, item1);
            _items.Add(item2.ProductId, item2);
        }

        public Storage(Dictionary<Guid, Item> items)
        {
            _items = items;
        }

        public void AddItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentException("Попытка добавления пустого item");
            }

            _items.Add(item.ProductId, item);
        }

        public Dictionary<Guid, Item> GetAllItems()
        {
            Dictionary<Guid, Item> items = _items.Copy();

            return items;
        }

        public List<string> GetItemsInfo()
        {
            List<string> itemsInfo = new List<string>();

            foreach (var itemEntry in _items)
            {
                itemsInfo.Add(itemEntry.Value.ProductInfo);
            }

            return itemsInfo;
        }

        public bool TryTakeItem(Guid productId, int quantity, out Item item)
        {
            item = null;

            if (_items.ContainsKey(productId))
            {
                Item foundItem = _items[productId];

                if (foundItem.Quantity > quantity)
                {
                    foundItem.DecreaseQuantity(quantity);
                    item = foundItem.Copy(quantity);

                    return true;
                }
            }

            return false;
        }
    }
}