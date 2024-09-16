using System;

namespace War.Entities
{
    public class Game
    {
        private Platoon _platoon1;
        private Platoon _platoon2;

        public Game(Platoon platoon1, Platoon platoon2)
        {
            _platoon1 = platoon1;
            _platoon2 = platoon2;
        }

        public void StartBattle()
        {
            int attackNumber = 1;

            while (_platoon1.HasAliveSoldiers() && _platoon2.HasAliveSoldiers())
            {
                bool canAllPlatoon1SoldiersAttack = _platoon1.TryAttack(_platoon2);
                bool canAllPlatoon2SoldiersAttack = true;

                _platoon2.RemoveDeadSoldiers();

                if (_platoon2.HasAliveSoldiers())
                {
                    canAllPlatoon2SoldiersAttack = _platoon2.TryAttack(_platoon1);
                    _platoon1.RemoveDeadSoldiers();
                }

                Console.WriteLine($"Атака №{attackNumber}");

                Console.WriteLine("Взвод 1:");
                ShowPlatoon(_platoon1);
                Console.WriteLine("Взвод 2:");
                ShowPlatoon(_platoon2);

                if (canAllPlatoon1SoldiersAttack && canAllPlatoon2SoldiersAttack)
                {
                    Console.WriteLine("Все солдаты обоих взводов провели свои атаки");
                }
                else
                {
                    Console.WriteLine("Взводы провели свои атаки, но не увсех солдат это получилось");
                }

                attackNumber++;
            }

            if (_platoon1.HasAliveSoldiers())
            {
                Console.WriteLine("Победил первый взвод!");
            }
            else if (_platoon2.HasAliveSoldiers())
            {
                Console.WriteLine("Победил второй взвод!");
            }
            else
            {
                Console.WriteLine("Оба взвода уничтожены!");
            }
        }

        private void ShowPlatoon(Platoon platoon)
        {
            Console.WriteLine(platoon);
        }
    }
}