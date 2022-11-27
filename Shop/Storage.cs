using System;
using System.Collections.Generic;

namespace Shop
{
    public class Storage
    {
        private List<Item> _items;
        
        public Storage()
        {
            _items = new List<Item>();
            
            Item apples = CreateItem(new Apple(0.176f, 14), 100);
            Item peaches = CreateItem(new Peach(0.15f, 30), 120);
            Item candies = CreateItem(new Candy(0.015f, 5), 50);
            Item backpacks = CreateItem(new Backpack(0.4f, 1200), 4);
            
            AddItem(apples);
            AddItem(peaches);
            AddItem(candies);
            AddItem(backpacks);
        }

        private void AddItem(Item item)
        {
            _items.Add(item);
        }

        private Item CreateItem(Product product, int productQuantity)
        {
            return new Item(product, productQuantity);
        }
        
        public void ShowItems()
        {
            foreach (Item goods in _items)
            {
                Console.WriteLine($"Продукт - {ProductName.ProductNames[goods.Product.GetType()]}, Количество - {goods.ProductQuantity}");
            }
        }

        public Item TakeItem(int quantity)
        {
            return _items[0];
        }
    }
}