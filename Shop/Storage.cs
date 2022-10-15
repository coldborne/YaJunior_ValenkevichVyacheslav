using System.Collections.Generic;

namespace Shop
{
    public class Storage
    {
        public List<Goods> Goods;
        
        public Storage()
        {
            Goods = new List<Goods>();
            
            Goods apples = CreateGoods(new Apple(0.176f, 14), 100);
            Goods peaches = CreateGoods(new Peach(0.15f, 30), 120);
            Goods candies = CreateGoods(new Candy(0.015f, 5), 50);
            Goods backpacks = CreateGoods(new Backpack(0.4f, 1200), 4);
            
            AddGoods(apples);
            AddGoods(peaches);
            AddGoods(candies);
            AddGoods(backpacks);
        }

        private void AddGoods(Goods goods)
        {
            Goods.Add(goods);
        }

        private Goods CreateGoods(Product product, int productQuantity)
        {
            return new Goods(product, productQuantity);
        }
    }
}