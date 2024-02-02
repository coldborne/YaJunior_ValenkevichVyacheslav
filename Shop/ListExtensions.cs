using System;
using System.Collections.Generic;

namespace Shop
{
    public static class ListExtensions
    {
        public static List<Merchandise> Copy(this List<Merchandise> merchandises)
        {
            List<Merchandise> copyMerchandises = new List<Merchandise>();

            foreach (var merchandise in merchandises)
            {
                copyMerchandises.Add(merchandise.Copy());
            }

            return copyMerchandises;
        }
    }
}