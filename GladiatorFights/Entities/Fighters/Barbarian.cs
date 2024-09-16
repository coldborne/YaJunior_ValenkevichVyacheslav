using System;
using GladiatorFights.Entities.Stats;

namespace GladiatorFights.Entities.Fighters;

public class Barbarian : Fighter
{
    private int _rageAmount;
    private readonly int _maxRageAmount;
    private readonly int _healingAmount;

    public Barbarian(string name, Health health, Damage damage) : base(name, health, damage)
    {
        _maxRageAmount = 100;
        _healingAmount = 20;
    }

    public override void Attack(Fighter target)
    {
        target.ReceiveDamage(Damage);
        _rageAmount += Damage;

        if (_rageAmount >= _maxRageAmount)
        {
            Treat(_healingAmount);
            _rageAmount = 0;
            Console.WriteLine($"{Name} исцеляется на {_healingAmount} здоровья. Теперь у {Name} {Health} здоровья.");
        }
    }

    public override Fighter Copy()
    {
        Fighter fighter = new Barbarian(Name, new Health(Health), new Damage(Damage));

        return fighter;
    }
}