namespace SmallShop
{
    public class Product
    {
        private readonly string _name;

        public int Price { get; private set; }
        public int Weight { get; private set; }

        public Product(string name, int weight, int price)
        {
            Weight = weight;
            _name = name;
            Price = price;
        }

        public void ChangePrice(int newPrice)
        {
            Price = newPrice;
        }

        public override string ToString()
        {
            return $"Название {_name}, Вес - {Weight}, Цена - {Price}";
        }
    }
}