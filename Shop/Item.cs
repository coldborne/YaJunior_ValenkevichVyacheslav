using System;

namespace Shop
{
    public class Item
    {
        private Product _product;

        public Item(Product product, int price, int quantity)
        {
            _product = product;
            Price = price;
            Quantity = quantity;
        }

        public int Price { get; private set; }
        public int Quantity { get; private set; }
        public Guid ProductId => _product.Id;
        public float ProductWeight => _product.Weight;
        public Type ProductType => _product.GetType();
        public string ProductInfo => _product.Info;

        public void DecreaseQuantity(int quantity)
        {
            if (quantity >= Quantity)
            {
                throw new ArgumentException("Количество продукта в товаре должно быть больше 0");
            }

            Quantity -= quantity;
        }

        public Item Copy()
        {
            return new Item(_product, Price, Quantity);
        }

        public Item Copy(int quantity)
        {
            return new Item(_product, Price, quantity);
        }
    }
}