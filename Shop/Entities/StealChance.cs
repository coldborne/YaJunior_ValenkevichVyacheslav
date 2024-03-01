using Shop.Providers;

namespace Shop
{
    public class StealChance
    {
        public StealChance()
        {
            int minStealChanceValue = 15;
            int maxStealChanceValue = 50;

            RandomValueProvider randomValueProvider = new RandomValueProvider();
            Value = randomValueProvider.GetRandomValue(minStealChanceValue, maxStealChanceValue);
        }

        public static int MinStealChance => 0;
        public static int MaxStealChance => 100;
        public int Value { get; }
    }
}