using System;
using War.Entities.Stats;

namespace War.Entities.Soldiers
{
    public class Sniper : Soldier
    {
        private double _damageMultiplier;

        public Sniper(Health health, Damage damage, Armor armor, double multiplier)
            : base(health, damage, armor)
        {
            _damageMultiplier = multiplier;
        }

        public override bool TryAttack(Platoon enemyPlatoon)
        {
            bool canGetTarget = enemyPlatoon.TryGetRandomSoldier(out Soldier target);

            if (canGetTarget)
            {
                int totalDamage = (int)Math.Ceiling(Damage.Value * _damageMultiplier);
                target.TakeDamage(totalDamage);
                return true;
            }

            return false;
        }
    }
}