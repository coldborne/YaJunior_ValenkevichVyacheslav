using System.Linq;

namespace SmallShop
{
    public class Customer : Person
    {
        private int _avaibleWeigth;

        public Customer() : base(500)
        {
            _avaibleWeigth = 5000;
        }

        public int FreeWeight => _avaibleWeigth - Products.Sum(productInBag => productInBag.Weight);

        public bool TryBuyProduct(Product product)
        {
            if (HasFreeWeight(product.Weight) == false || CanPay(product.Price) == false)
            {
                return false;
            }

            Products.Add(product);
            Money -= product.Price;

            return true;
        }

        private bool HasFreeWeight(int weight)
        {
            return weight <= FreeWeight;
        }

        private bool CanPay(int price)
        {
            return price <= Money;
        }
    }
}