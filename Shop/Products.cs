using System;
using Shop.Enums;
using Type = Shop.Enums.Type;

namespace Shop
{
    public abstract class Product
    {
        public Product(DateTime expirationDate)
        {
            Id = Guid.NewGuid();
            ExpirationDate = expirationDate;
        }

        public Guid Id { get; }
        public DateTime ExpirationDate { get; }
    }

    public class Apple : Product
    {
        public Apple(DateTime expirationDate, string info, Variety variety, Taste taste) : base(expirationDate)
        {
            Variety = variety;
            Taste = taste;
        }

        public Variety Variety { get; }
        public Taste Taste { get; }
    }

    public class Peach : Product
    {
        public Peach(DateTime expirationDate, string info, float fuzziness) : base(expirationDate)
        {
            int minFuzziness = 0;
            int maxFuzziness = 1;

            if (fuzziness < minFuzziness || fuzziness > maxFuzziness)
            {
                throw new ArgumentException($"Пушистость должна быть в пределах от {minFuzziness} до {maxFuzziness}");
            }

            Fuzziness = fuzziness;
        }

        public float Fuzziness { get; }
    }

    public class Candy : Product
    {
        public Candy(DateTime expirationDate, string info, float sugarContent) : base(expirationDate)
        {
            int minSugarContent = 0;
            int maxSugarContent = 1;

            if (sugarContent < minSugarContent || sugarContent > maxSugarContent)
            {
                throw new ArgumentException(
                    $"Содержание сахара должно быть в пределах от {minSugarContent} до {maxSugarContent}");
            }

            SugarContent = sugarContent;
        }

        public float SugarContent { get; }
        public Flavor Flavor { get; }
        public Type Type { get; }
    }

    public class Backpack : Product
    {
        public Backpack(DateTime expirationDate, string info, int pocketsAmount, Material material) : base(
            expirationDate)
        {
            PocketAmount = pocketsAmount;
            Material = material;
        }

        public int PocketAmount { get; }
        public Material Material { get; }
    }
}