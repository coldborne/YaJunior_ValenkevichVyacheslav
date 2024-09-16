using System;

namespace War.Entities.Stats
{
    public class Health
    {
        private static readonly int _minHealth = 0;
        private static readonly int _maxHealth = 100;

        public Health(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }

        public void Decrease(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Damage cannot be negative.");

            Value = Math.Max(Value - amount, _minHealth);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}