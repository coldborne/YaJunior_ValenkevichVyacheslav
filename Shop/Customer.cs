using System.Collections.Generic;

namespace Shop
{
    public class Customer
    {
        private int _money;
        private int _bagCapacity;
        private List<Product> _productsInBag;

        public bool CanBuy(Product product)
        {
            return true;
        }
    }
}