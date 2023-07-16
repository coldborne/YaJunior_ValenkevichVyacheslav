namespace SmallShop
{
    public class Product
    {
        public Product(string name, int weight, int price)
        {
            Weight = weight;
            Name = name;
            Price = price;
        }
        
        public string Name { get; }
        public int Price { get; }
        public int Weight { get; }
        
        public override string ToString()
        {
            return "Название - " + Name + ", Вес - " + Weight + ", Цена - " + Price;
        }
    }
}