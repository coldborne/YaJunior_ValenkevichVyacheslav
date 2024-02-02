using System;

namespace Shop
{
    public class Merchandise
    {
        public Merchandise(Product product, Category category, int price, int quantity)
        {
            Product = product;
            Category = category;
            Price = price;
            Quantity = quantity;
        }

        public Product Product { get; }
        public int Price { get; private set; }
        public int Quantity { get; private set; }
        public Category Category { get; }

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
            return new Merchandise(Product, Category, Price, Quantity);
        }
    }

    public enum Category
    {
        Food,
        Electronics,
        Clothing
    }
}