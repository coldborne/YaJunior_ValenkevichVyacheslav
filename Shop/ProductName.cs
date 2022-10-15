using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Shop
{
    public static class ProductName
    {
        public static Dictionary<Type, string> ProductNames = new Dictionary<Type, string>()
        {
            {typeof(Apple), "Яблоко"},
            {typeof(Peach), "Грушка"},
            {typeof(Candy), "Конфеты"},
            {typeof(Backpack), "Рюкзак"}
        };
    }
}