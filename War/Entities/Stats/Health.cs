using System;

namespace War.Entities.Stats
{
    public class Health
    {
        private readonly int s_minHealth;
        private readonly int s_maxHealth;

        public Health(int value)
        {
            s_minHealth = 0;
            s_maxHealth = 100;
            Value = value;
        }

        public int Value { get; private set; }

        public void Decrease(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Damage cannot be negative.");

            Value = Math.Max(Value - amount, s_minHealth);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}