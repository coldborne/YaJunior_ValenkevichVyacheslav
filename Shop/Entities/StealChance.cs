using Shop.Providers;

namespace Shop
{
    public class StealChance
    {
        public StealChance()
        {
            int minStealChanceValue = 15;
            int maxStealChanceValue = 50;

            Value = RandomValueProvider.GetRandomValue(minStealChanceValue, maxStealChanceValue);
        }

        public int Value { get; }

        public static int MinStealChance => 0;
        public static int MaxStealChance => 100;
    }
}