using System;
using System.Collections.Generic;

namespace Gladiator_fights
{
    public class Arena
    {
        private List<Fighter> _fighters;

        public Arena()
        {
            _fighters = new List<Fighter>();
            FillFightersList();
        }

        private bool TryAddFighter(Fighter fighter)
        {
            if (fighter == null) return false;

            _fighters.Add(fighter);
            return true;
        }

        public void ShowAllFighters()
        {
            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.Write($"{i + 1} - ");
                _fighters[i].ShowStats();
            }
        }

        public int GetFightersCount()
        {
            return _fighters.Count;
        }

        public Fighter CreateFighter(int id)
        {
            if (id <= 0 || id > _fighters.Count)
            {
                return null;
            }
            else
            {
                return (Fighter)_fighters[id-1].Clone();
            }
        }

        private void FillFightersList()
        {
            TryAddFighter(new Cleric());
            TryAddFighter(new Thief());
            TryAddFighter(new Paladin());
            TryAddFighter(new Mage());
            TryAddFighter(new Barbarian());
        }
    }
}