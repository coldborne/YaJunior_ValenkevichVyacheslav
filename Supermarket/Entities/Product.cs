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
            Product copyProduct = new Product(Name, Price);

            return copyProduct;
        }

        public override string ToString()
        {
            return $"Название - {Name}, Цена - {Price}";
        }
    }
}