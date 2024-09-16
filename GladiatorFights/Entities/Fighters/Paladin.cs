using System;
using GladiatorFights.Entities.Stats;

namespace GladiatorFights.Entities.Fighters;

public class Paladin : Fighter
{
    private Random _random;
    private readonly double _maxDoubleDamageChanceValue;

    public Paladin(string name, Health health, Damage damage)
        : base(name, health, damage)
    {
        _random = new Random();
        _maxDoubleDamageChanceValue = 0.2;
    }

    public override void Attack(Fighter target)
    {
        int finalDamage = Damage;
        double doubleDamageChanceValue = _random.NextDouble();

        if (doubleDamageChanceValue < _maxDoubleDamageChanceValue)
        {
            int damageModifier = 2;
            finalDamage *= damageModifier;
            Console.WriteLine($"{Name} наносит удвоенный урон!");
        }

        target.ReceiveDamage(finalDamage);
        Console.WriteLine(
            $"{Name} атакует {target.Name} на {finalDamage} урона. У {target.Name} осталось {target.Health} здоровья.");
    }

    public override Fighter Copy()
    {
        Fighter fighter = new Paladin(Name, new Health(Health), new Damage(Damage));

        return fighter;
    }
}