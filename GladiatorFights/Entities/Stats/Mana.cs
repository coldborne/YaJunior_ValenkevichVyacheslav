using System;

namespace GladiatorFights.Fighters;

public class Mana
{
    public Mana(int value)
    {
        Value = value;
    }

    public int Value { get; private set; }

    public void Increase(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Mana cannot be negative.");

        Value += amount;
    }

    public void Decrease(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Mana cannot be negative.");

        Value -= amount;
    }
}