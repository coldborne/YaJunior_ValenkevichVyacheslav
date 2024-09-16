namespace War.Entities.Stats
{
    public class Damage
    {
        private static readonly int s_minDamage = 0;

        public Damage(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}