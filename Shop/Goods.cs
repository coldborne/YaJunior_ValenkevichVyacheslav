namespace Shop
{
    public class Goods
    {
        public Product Product { get; private set; }
        public int ProductQuantity { get; private set; }
        
        public Goods(Product product, int productQuantity)
        {
            Product = product;
            ProductQuantity = productQuantity;
        }
    }
}