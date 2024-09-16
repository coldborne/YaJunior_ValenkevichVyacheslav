using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using War.Entities.Soldiers;

namespace War.Entities
{
    public class Platoon
    {
        private List<Soldier> _soldiers = new List<Soldier>();
        private Random _random = new Random();

        public int Count => _soldiers.Count;

        public void AddSoldier(Soldier soldier)
        {
            _soldiers.Add(soldier);
        }

        public bool TryGetRandomSoldier(out Soldier soldier)
        {
            if (_soldiers.Count == 0)
            {
                soldier = null;
                return false;
            }

            int index = _random.Next(_soldiers.Count);
            soldier = _soldiers[index];

            return true;
        }

        public List<Soldier> GetRandomSoldiers(int count, bool allowDuplicates)
        {
            List<Soldier> selectedSoldiers = new List<Soldier>();

            if (allowDuplicates)
            {
                for (int i = 1; i <= count; i++)
                {
                    bool canGetTarget = TryGetRandomSoldier(out Soldier soldier);

                    if (canGetTarget)
                    {
                        selectedSoldiers.Add(soldier);
                    }
                }
            }
            else
            {
                List<Soldier> shuffledSoldiers = _soldiers.OrderBy(soldier => _random.Next()).ToList();
                
                selectedSoldiers = shuffledSoldiers.Take(count).ToList();
            }

            return selectedSoldiers;
        }

        public void RemoveDeadSoldiers()
        {
            _soldiers = _soldiers.Where(soldier => soldier.Health.Value > 0).ToList();
        }

        public bool HasAliveSoldiers()
        {
            return _soldiers.Any(soldier => soldier.Health.Value > 0);
        }

        public void Attack(Platoon enemyPlatoon)
        {
            foreach (var soldier in _soldiers)
            {
                soldier.TryAttack(enemyPlatoon);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Отряд имеет следующих солдат:");

            if (_soldiers.Count > 0)
            {
                foreach (Soldier soldier in _soldiers)
                {
                    stringBuilder.AppendLine(soldier.ToString());
                }
            }
            else
            {
                stringBuilder.AppendLine("В отряде закончились бойцы");
            }

            return stringBuilder.ToString();
        }
    }
}