using System.Collections;

namespace Shop
{
    public class Item
    {
        public Product Product { get; private set; }
        public int ProductQuantity { get; private set; }
        
        public Item(Product product, int productQuantity)
        {
            Product = product;
            ProductQuantity = productQuantity;
        }
    }
}