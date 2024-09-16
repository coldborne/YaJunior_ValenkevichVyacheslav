using GladiatorFights.Entities.Stats;

namespace GladiatorFights.Entities.Fighters
{
    public abstract class Fighter
    {
        private Damage _damage;
        private Health _health;

        protected Fighter(string name, Health health, Damage damage)
        {
            Name = name;
            _damage = damage;
            _health = health;
        }

        public string Name { get; private set; }
        public int Damage => _damage.Value;
        public int Health => _health.Value;

        public virtual void ReceiveDamage(int damage)
        {
            _health.Decrease(damage);
        }

        public void Treat(int amount)
        {
            _health.Increase(amount);
        }

        public override string ToString()
        {
            return $"Боец: {Name}, Здоровье: {Health}, Урон: {Damage}";
        }

        public abstract void Attack(Fighter target);
        public abstract Fighter Copy();
    }
}