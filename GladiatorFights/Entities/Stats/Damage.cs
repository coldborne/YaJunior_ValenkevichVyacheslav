using System;

namespace GladiatorFights.Entities.Stats;

public class Damage
{
    private static readonly int _minDamage = 0;

    public Damage(int value)
    {
        Value = value;
    }

    public int Value { get; private set; }

    public void Increase(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Damage cannot be negative.");

        Value += amount;
    }

    public void Decrease(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Damage cannot be negative.");

        Value = Math.Max(Value - amount, _minDamage);
    }
}