using System;
using GladiatorFights.Entities.Stats;

namespace GladiatorFights.Entities.Fighters;

public class Mage : Fighter
{
    private Mana _mana;
    private readonly int _fireBallDamage;
    private readonly int _manaCost;

    public Mage(string name, Health health, Damage damage, Mana mana) : base(name, health, damage)
    {
        _mana = mana;
        _fireBallDamage = 30;
        _manaCost = 10;
    }

    public int Mana => _mana.Value;

    public override void Attack(Fighter target)
    {
        if (Mana >= _manaCost)
        {
            _mana.Decrease(_manaCost);
            target.ReceiveDamage(_fireBallDamage);
            Console.WriteLine(
                $"{Name} использует Огненный Шар и наносит {_fireBallDamage} урона. У {target.Name} осталось {target.Health} здоровья.");
        }
        else
        {
            target.ReceiveDamage(Damage);
            Console.WriteLine(
                $"{Name} атакует {target.Name} на {Damage} урона. У {target.Name} осталось {target.Health} здоровья.");
        }
    }
    
    public override Fighter Copy()
    {
        Fighter fighter = new Mage(Name, new Health(Health), new Damage(Damage), new Mana(Mana));

        return fighter;
    }
}