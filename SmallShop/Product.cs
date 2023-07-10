namespace SmallShop
{
    public class Product
    {
        public string Name { get; }
        public int Price { get; }
        public int Weight { get; }

        public Product(string name, int weight, int price)
        {
            Weight = weight;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return "Название - " + Name + ", Вес - " + Weight + ", Цена - " + Price;
        }
    }
}