using System;

namespace War.Entities.Stats
{
    public class Armor
    {
        private static readonly int _minArmor = 0;
        private static readonly int _maxArmor = 400;

        public Armor(int value)
        {
            if (value < _minArmor)
                throw new ArgumentException("Armor cannot be negative.");

            Value = Math.Min(value, _maxArmor);
        }

        public int Value { get; }

        public double GetDamageReductionPercentage()
        {
            return (double)Value / (Value + 100);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}