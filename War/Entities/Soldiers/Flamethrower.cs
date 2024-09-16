using System;
using System.Collections.Generic;
using War.Entities.Stats;

namespace War.Entities.Soldiers
{
    public class Flamethrower : Soldier
    {
        private Random _random;

        public Flamethrower(Health health, Damage damage, Armor armor)
            : base(health, damage, armor)
        {
            _random = new Random();
        }

        public override bool TryAttack(Platoon enemyPlatoon)
        {
            int attackedSoldiersAmount = _random.Next(enemyPlatoon.Count);
            List<Soldier> targets = enemyPlatoon.GetRandomSoldiers(attackedSoldiersAmount, allowDuplicates: true);

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