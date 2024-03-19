using System;
using System.Collections.Generic;

namespace Shop
{
    public class Seller : Person
    {
        public Seller(int money) : base(money)
        {
        }

        public Seller(int money, Dictionary<Guid, Merchandise> merchandises) : base(money, merchandises)
        {
        }

        public bool TrySellMerchandise(Guid productId, int quantity)
        {
            return TryDecreaseMerchandiseQuantity(productId, quantity);
        }
    }
}