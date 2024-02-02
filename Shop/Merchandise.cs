using System;

namespace Shop
{
    public class Merchandise
    {
        public Merchandise(Product product, int price, int quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
        }

        public Product Product { get; }
        public int Price { get; private set; }
        public int Quantity { get; private set; }

        public void DecreaseQuantity(int quantity)
        {
            if (quantity >= Quantity)
            {
                throw new ArgumentException("Количество продукта в товаре должно быть больше 0");
            }

            Quantity -= quantity;
        }

        public Merchandise Copy()
        {
            return new Merchandise(Product, Price, Quantity);
        }

        public Merchandise Copy(int quantity)
        {
            return new Merchandise(Product, Price, quantity);
        }
    }
}