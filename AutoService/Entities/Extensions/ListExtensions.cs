using AutoService.Entities.Interfaces;

namespace AutoService.Entities.Extensions
{
    public static class ListExtensions
    {
        public static List<T> Copy<T>(this List<T> list) where T : ICopyable<T>
        {
            List<T> copyList = new List<T>();

            foreach (T item in list)
            {
                copyList.Add(item.Copy());
            }

            return copyList;
        }
    }
}