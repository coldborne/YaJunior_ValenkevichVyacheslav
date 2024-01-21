using System;

namespace Shop
{
    public class Item
    {
        private Product _product;

        public Item(Product product, int quantity)
        {
            _product = product;
            Quantity = quantity;
        }

        public Type ProductType => _product.GetType();
        public int ProductPrice => _product.Price;
        public Guid ProductId => _product.Id;
        public int Quantity { get; private set; }
    }
}