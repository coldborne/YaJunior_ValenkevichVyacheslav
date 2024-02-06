using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Enums;

namespace Shop
{
    public class MerchandiseCreator
    {
        private static Random _random = new Random();

        public static List<Merchandise> CreateUniqueMerchandiseList(int merchandiseQuantity)
        {
            List<Merchandise> merchandises = new List<Merchandise>();

            for(int i = 0; i < merchandiseQuantity; i++)
            {
                var categories = GenerateCategories();
                var primaryCategory = categories.First();
                var name = GenerateName(primaryCategory);
                var expirationDate = DateTime.Today.AddDays(_random.Next(-30, 90));

                int minPrice = 1;
                int maxPrice = 100;
                var price = _random.Next(minPrice, maxPrice);

                int minQuantity = 1;
                int maxQuantity = 50;
                var quantity = _random.Next(minQuantity, maxQuantity);

                Product product = null;

                switch (primaryCategory)
                {
                    case Category.Food:
                        product = new Apple(name,
                            expirationDate,
                            (Variety)_random.Next(Enum.GetValues(typeof(Variety)).Length),
                            Taste.Sugary);
                        break;

                    case Category.Clothing:
                        product = new Backpack(name, expirationDate, 5, Material.Leather);
                        break;
                }

                if (product != null)
                {
                    merchandises.Add(new Merchandise(product, categories, price, quantity));
                }
            }

            return merchandises;
        }

        private static string GenerateName(Category category)
        {
            var foodNames = new List<string> { "Яблоко", "Персик", "Чокопай" };
            var clothingNames = new List<string> { "Рюкзак", "Куртка", "Шапка" };
            var electronicsNames = new List<string> { "Наушники", "Смартфон", "Планшет" };

            switch (category)
            {
                case Category.Food:
                    return foodNames[_random.Next(foodNames.Count)];
                case Category.Clothing:
                    return clothingNames[_random.Next(clothingNames.Count)];
                case Category.Electronics:
                    return electronicsNames[_random.Next(electronicsNames.Count)];
                default:
                    return "Неизвестный товар";
            }
        }

        private static List<Category> GenerateCategories()
        {
            var allCategories = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
            var categories = new List<Category>();
            var numberOfCategories = _random.Next(1, 4); // От 1 до 3 категорий для товара

            for(int i = 0; i < numberOfCategories; i++)
            {
                var categoryToAdd = allCategories[_random.Next(allCategories.Count)];

                if (!categories.Contains(categoryToAdd))
                {
                    categories.Add(categoryToAdd);
                }
            }

            return categories;
        }
    }
}