using System.Collections.Generic;

namespace Shop
{
    public static class ListExtensions
    {
        public static List<T> DeepCopy<T>(this List<T> items) where T : ICopyable<T>
        {
            List<T> copiedItems = new List<T>();

            foreach (T item in items)
            {
                copiedItems.Add(item.DeepCopy());
            }

            return copiedItems;
        }

        public static List<T> ShallowCopy<T>(this List<T> listToCopy) where T : struct
        {
            return new List<T>(listToCopy);
        }

        public static List<Merchandise> SortByMultipleCriteria(this List<Merchandise> merchandises)
        {
            List<Merchandise> sortedMerchandises = merchandises.DeepCopy();
            sortedMerchandises.Sort();

            return sortedMerchandises;
        }
    }
}