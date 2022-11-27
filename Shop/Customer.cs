using System.Collections.Generic;

namespace Shop
{
    public class Customer
    {
        private const int _maxBagWeight = 20;

        private int _money;
        private int _bagWeight;
        private List<Item> _productsInBag;

        public void PutGoodsInBag(Item item)
        {
            _productsInBag.Add(item);
        }
        
        public bool CanBuy(Product product, int productQuantity)
        {
            float capacity = product.Weight * productQuantity;
            float price = product.Price * productQuantity;

            float sumOfGoods = 0;

            foreach (var goods in _productsInBag)
            {
                sumOfGoods += goods.Product.Price + goods.ProductQuantity;
            }

            return capacity + _bagWeight <= _maxBagWeight && price <= _money - sumOfGoods;
        }
    }
}