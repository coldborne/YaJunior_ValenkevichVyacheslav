using System;
using Shop.Enums;
using Type = Shop.Enums.Type;

namespace Shop
{
    public abstract class Product
    {
        public Product(string name, DateTime expirationDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            ExpirationDate = expirationDate;
            Description = GenerateDescription();
        }

        public Guid Id { get; }
        public string Name { get; }
        public DateTime ExpirationDate { get; }
        public string Description { get; }

        protected abstract string GenerateDescription();

        public override string ToString()
        {
            return $"Название - {Name}, Срок годности - {ExpirationDate.ToShortDateString()}, Описание - {Description}";
        }
    }

    public class Apple : Product
    {
        public Apple(string name, DateTime expirationDate, Variety variety, Taste taste) : base(name, expirationDate)
        {
            Variety = variety;
            Taste = taste;
        }

        public Variety Variety { get; }
        public Taste Taste { get; }

        protected override string GenerateDescription()
        {
            return $"Сорт: {Variety}, вкус: {Taste}. Очень сочные и ароматные, идеальны для свежего потребления.";
        }
    }

    public class Peach : Product
    {
        public Peach(string name, DateTime expirationDate, float fuzziness) : base(name, expirationDate)
        {
            int minFuzziness = 0;
            int maxFuzziness = 1;

            if (fuzziness < minFuzziness || fuzziness > maxFuzziness)
            {
                throw new ArgumentException($"Пушистость должна быть в пределах " +
                                            $"от {minFuzziness} до {maxFuzziness}");
            }

            Fuzziness = fuzziness;
        }

        public float Fuzziness { get; }

        protected override string GenerateDescription()
        {
            return
                $"Спелый персик с {Fuzziness * 100}% пушистостью кожицы. Отличается невероятной сочностью и " +
                $"сладостью, подходит для летних десертов.";
        }
    }

    public class Candy : Product
    {
        public Candy(string name, DateTime expirationDate, float sugarContent, Flavor flavor, Type type) : base(name,
            expirationDate)
        {
            int minSugarContent = 0;
            int maxSugarContent = 1;

            if (sugarContent < minSugarContent || sugarContent > maxSugarContent)
            {
                throw new ArgumentException(
                    $"Содержание сахара должно быть в пределах от {minSugarContent} до {maxSugarContent}");
            }

            SugarContent = sugarContent;
            Flavor = flavor;
            Type = type;
        }

        public float SugarContent { get; }
        public Flavor Flavor { get; }
        public Type Type { get; }

        protected override string GenerateDescription()
        {
            return
                $"Конфеты с {Flavor} вкусом и типом '{Type}'. Каждая конфета обеспечивает яркий вкусовой опыт и " +
                $"станет отличным дополнением к чаепитию.";
        }
    }

    public class Backpack : Product
    {
        public Backpack(string name, DateTime expirationDate, int pocketsAmount, Material material) : base(name,
            expirationDate)
        {
            PocketAmount = pocketsAmount;
            Material = material;
        }

        public int PocketAmount { get; }
        public Material Material { get; }

        protected override string GenerateDescription()
        {
            return
                $"Рюкзак изготовлен из {Material}, имеет {PocketAmount} карманов. Прочный и вместительный, " +
                $"идеален для путешествий и повседневного использования.";
        }
    }
}