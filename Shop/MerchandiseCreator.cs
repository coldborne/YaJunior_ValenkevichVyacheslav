using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Enums;
using Shop.Providers;

namespace Shop
{
    public class MerchandiseCreator
    {
        private static RandomValueProvider _randomProvider = new RandomValueProvider();

        public List<Merchandise> CreateUniqueMerchandiseList(int merchandiseQuantity)
        {
            List<Merchandise> merchandises = new List<Merchandise>();

            for(int i = 1; i <= merchandiseQuantity; i++)
            {
                List<MerchandiseCategory> categories = GenerateCategories();
                MerchandiseCategory primaryCategory = categories.First();
                string name = GenerateName(primaryCategory);

                int minimumAllowanceExpirationDays = -30;
                int maximumAllowanceExpirationDays = 90;
                DateTime expirationDate = DateTime.Today.AddDays(
                    _randomProvider.GetRandomValue(minimumAllowanceExpirationDays, maximumAllowanceExpirationDays));

                int minPrice = 1;
                int maxPrice = 100;
                int price = _randomProvider.GetRandomValue(minPrice, maxPrice);

                int minQuantity = 1;
                int maxQuantity = 50;
                int quantity = _randomProvider.GetRandomValue(minQuantity, maxQuantity);

                Product product = null;

                switch (primaryCategory)
                {
                    case MerchandiseCategory.Food:
                        product = new Apple(name,
                            expirationDate,
                            (Variety)_randomProvider.GetRandomValue(Enum.GetValues(typeof(Variety)).Length),
                            Taste.Sugary);
                        break;

                    case MerchandiseCategory.Clothing:
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

        private string GenerateName(MerchandiseCategory merchandiseCategory)
        {
            List<string> foodNames = new List<string> { "Яблоко", "Персик", "Чокопай" };
            List<string> clothingNames = new List<string> { "Рюкзак", "Куртка", "Шапка" };
            List<string> electronicsNames = new List<string> { "Наушники", "Смартфон", "Планшет" };

            switch (merchandiseCategory)
            {
                case MerchandiseCategory.Food:
                    return foodNames[_randomProvider.GetRandomValue(foodNames.Count)];

                case MerchandiseCategory.Clothing:
                    return clothingNames[_randomProvider.GetRandomValue(clothingNames.Count)];

                case MerchandiseCategory.Electronics:
                    return electronicsNames[_randomProvider.GetRandomValue(electronicsNames.Count)];

                default:
                    return "Неизвестный товар";
            }
        }

        private List<MerchandiseCategory> GenerateCategories()
        {
            List<MerchandiseCategory> allCategories =
                Enum.GetValues(typeof(MerchandiseCategory)).Cast<MerchandiseCategory>().ToList();

            List<MerchandiseCategory> categories = new List<MerchandiseCategory>();

            int minimumCategoriesAmount = 1;
            int maximumCategoriesAmount = 4;
            int categoriesAmount = _randomProvider.GetRandomValue(minimumCategoriesAmount, maximumCategoriesAmount + 1);

            for(int i = 0; i < categoriesAmount; i++)
            {
                MerchandiseCategory categoryToAdd = allCategories[_randomProvider.GetRandomValue(allCategories.Count)];

                if (categories.Contains(categoryToAdd) == false)
                {
                    categories.Add(categoryToAdd);
                }
            }

            return categories;
        }
    }
}