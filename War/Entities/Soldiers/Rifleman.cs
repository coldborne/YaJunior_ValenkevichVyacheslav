using War.Entities.Stats;

namespace War.Entities.Soldiers
{
    public class Rifleman : Soldier
    {
        public Rifleman(Health health, Damage damage, Armor armor)
            : base(health, damage, armor)
        {
        }

        public override bool TryAttack(Platoon enemyPlatoon)
        {
            bool canGetTarget = enemyPlatoon.TryGetRandomSoldier(out Soldier target);

            if (canGetTarget)
            {
                target.TakeDamage(Damage.Value);
                return true;
            }

            return false;
        }
    }
}