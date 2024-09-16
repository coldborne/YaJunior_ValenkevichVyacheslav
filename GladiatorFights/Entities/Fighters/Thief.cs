using System;
using GladiatorFights.Entities.Stats;

namespace GladiatorFights.Entities.Fighters;

public class Thief : Fighter
{
    private Random _random;
    private readonly double _maxEvasionChanceValue;

    public Thief(string name, Health health, Damage damage)
        : base(name, health, damage)
    {
        _random = new Random();
        _maxEvasionChanceValue = 0.2;
    }

    public override void Attack(Fighter target)
    {
        target.ReceiveDamage(Damage);
        Console.WriteLine(
            $"{Name} атакует {target.Name} на {Damage} урона. У {target.Name} осталось {target.Health} здоровья.");
    }

    public override void ReceiveDamage(int damage)
    {
        double evasionChanceValue = _random.NextDouble();

        if (evasionChanceValue < _maxEvasionChanceValue)
        {
            Console.WriteLine($"{Name} уклоняется от атаки!");
        }
        else
        {
            base.ReceiveDamage(Damage);
        }
    }
    
    public override Fighter Copy()
    {
        Fighter fighter = new Thief(Name, new Health(Health), new Damage(Damage));

        return fighter;
    }
}