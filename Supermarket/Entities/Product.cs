namespace Supermarket.Entities
{
    public class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public int Price { get; }

        public Product Copy()
        {
            return new Product(Name, Price);
        }

        public override string ToString()
        {
            return $"Название - {Name}, Цена - {Price}";
        }
    }
}