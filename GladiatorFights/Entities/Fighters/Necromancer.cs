using System;
using GladiatorFights.Entities.Stats;

namespace GladiatorFights.Entities.Fighters;

public class Necromancer : Fighter
{
    private int _inRowAttackCounter = 0;
    private readonly int _maxInRowAttackCounter;

    public Necromancer(string name, Health health, Damage damage) : base(name, health, damage)
    {
        _maxInRowAttackCounter = 3;
    }

    public override void Attack(Fighter target)
    {
        _inRowAttackCounter++;
        int finalDamage = Damage;

        if (_inRowAttackCounter % _maxInRowAttackCounter == 0)
        {
            int damageModifier = 2;
            finalDamage *= damageModifier;
            Console.WriteLine($"{Name} наносит двойной удар!");
        }

        target.ReceiveDamage(finalDamage);
        Console.WriteLine(
            $"{Name} атакует {target.Name} на {finalDamage} урона. У {target.Name} осталось {target.Health} здоровья.");
    }
    
    public override Fighter Copy()
    {
        Fighter fighter = new Necromancer(Name, new Health(Health), new Damage(Damage));

        return fighter;
    }
}