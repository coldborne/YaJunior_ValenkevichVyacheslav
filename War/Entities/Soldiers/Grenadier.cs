using System;
using System.Collections.Generic;
using War.Entities.Stats;

namespace War.Entities.Soldiers
{
    public class Grenadier : Soldier
    {
        private Random _random;

        public Grenadier(Health health, Damage damage, Armor armor)
            : base(health, damage, armor)
        {
            _random = new Random();
        }

        public override bool TryAttack(Platoon enemyPlatoon)
        {
            int attackedSoldiersAmount = _random.Next(enemyPlatoon.Count + 1);
            List<Soldier> targets = enemyPlatoon.GetRandomSoldiers(attackedSoldiersAmount, allowDuplicates: false);

            if (targets.Count == 0)
            {
                return false;
            }
            
            foreach (Soldier target in targets)
            {
                target.TakeDamage(Damage.Value);
            }

            return true;
        }
    }
}