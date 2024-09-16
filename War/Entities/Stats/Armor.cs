using System;

namespace War.Entities.Stats
{
    public class Armor
    {
        private readonly int _minArmor;
        private readonly int _maxArmor;

        public Armor(int value)
        {
            _minArmor = 0;
            _maxArmor = 400;

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