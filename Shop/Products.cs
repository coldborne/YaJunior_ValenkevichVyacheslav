using System;

namespace Shop
{
    public abstract class Product
    {
        public Product(float weight, int price)
        {
            Id = Guid.NewGuid();
            Weight = weight;
            Price = price;
        }

        public Guid Id { get; private set; }
        public float Weight { get; private set; }
        public int Price { get; private set; }
    }

    public class Apple : Product
    {
        public Apple(float weight, int price) : base(weight, price)
        {
        }
    }

    public class Peach : Product
    {
        public Peach(float weight, int price) : base(weight, price)
        {
        }
    }

    public class Candy : Product
    {
        public Candy(float weight, int price) : base(weight, price)
        {
        }
    }

    public class Backpack : Product
    {
        public Backpack(float weight, int price) : base(weight, price)
        {
        }
    }
}