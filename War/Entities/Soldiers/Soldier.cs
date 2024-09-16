using System;
using War.Entities.Stats;

namespace War.Entities.Soldiers
{
    public abstract class Soldier
    {
        public Health Health { get; }
        public Damage Damage { get; }
        public Armor Armor { get; }

        public Soldier(Health health, Damage damage, Armor armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public abstract bool TryAttack(Platoon enemyPlatoon);

        public void TakeDamage(int incomingDamage)
        {
            double damageReduction = Armor.GetDamageReductionPercentage();
            int damageAfterArmor = (int)(incomingDamage * (1 - damageReduction));
            
            damageAfterArmor = Math.Max(damageAfterArmor, 0);

            Health.Decrease(damageAfterArmor);
        }

        public override string ToString()
        {
            return $"Солдат: {GetType().Name}, Здоровье: {Health}, Урон: {Damage}, Броня: {Armor}";
        }
    }
}