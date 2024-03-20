using System;
using Shop.Enums;

namespace Shop
{
    public abstract class Product : ICopyable<Product>
    {
        public Product(string name, DateTime expirationDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            ExpirationDate = expirationDate;
        }

        public Guid Id { get; }
        public string Name { get; }
        public DateTime ExpirationDate { get; }

        public abstract string GetDescription();

        public abstract Product DeepCopy();

        public override string ToString()
        {
            return
                $"Название - {Name}, Срок годности - {ExpirationDate.ToShortDateString()}, Описание - {GetDescription()}";
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

        public override string GetDescription()
        {
            return $"Сорт: {Variety}, вкус: {Taste}. Очень сочные и ароматные, идеальны для свежего потребления.";
        }

        public override Product DeepCopy()
        {
            return new Apple(Name, ExpirationDate, Variety, Taste);
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

        public override string GetDescription()
        {
            return
                $"Спелый персик с {Fuzziness * 100}% пушистостью кожицы. Отличается невероятной сочностью и " +
                $"сладостью, подходит для летних десертов.";
        }

        public override Product DeepCopy()
        {
            return new Peach(Name, ExpirationDate, Fuzziness);
        }
    }

    public class Candy : Product
    {
        public Candy(string name, DateTime expirationDate, float sugarContent, Flavor flavor,
            CandyType candyType) : base(name,
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
            CandyType = candyType;
        }

        public float SugarContent { get; }
        public Flavor Flavor { get; }
        public CandyType CandyType { get; }

        public override string GetDescription()
        {
            return
                $"Конфеты с {Flavor} вкусом и типом '{CandyType}'. Каждая конфета обеспечивает яркий вкусовой опыт и " +
                $"станет отличным дополнением к чаепитию.";
        }

        public override Product DeepCopy()
        {
            return new Candy(Name, ExpirationDate, SugarContent, Flavor, CandyType);
        }
    }

    public class Backpack : Product
    {
        public Backpack(string name, DateTime expirationDate, int pocketAmount, Material material) : base(name,
            expirationDate)
        {
            PocketAmount = pocketAmount;
            Material = material;
        }

        public int PocketAmount { get; }
        public Material Material { get; }

        public override string GetDescription()
        {
            return
                $"Рюкзак изготовлен из {Material}, имеет {PocketAmount} карманов. Прочный и вместительный, " +
                $"идеален для путешествий и повседневного использования.";
        }

        public override Product DeepCopy()
        {
            return new Backpack(Name, ExpirationDate, PocketAmount, Material);
        }
    }
}