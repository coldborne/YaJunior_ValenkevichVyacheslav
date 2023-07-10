using System.Collections.Generic;

namespace SmallShop
{
    public class Seller : Person
    {
        public Seller(List<Product> products) : base(100000)
        {
            Products = products;
        }

        public void SellProduct(Product product)
        {
            Products.Remove(product);
            Money += product.Price;
        }

        public bool TryGetProduct(string name, out Product product)
        {
            product = Products.Find(myProduct => myProduct.Name == name);

            if (product == null)
            {
                return false;
            }

            return true;
        }
    }
}