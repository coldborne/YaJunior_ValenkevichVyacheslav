using System;
using War.Entities;

namespace War
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
                _platoon1.Attack(_platoon2);
                _platoon2.RemoveDeadSoldiers();

                if (_platoon2.HasAliveSoldiers())
                {
                    _platoon2.Attack(_platoon1);
                    _platoon1.RemoveDeadSoldiers();
                }

                Console.WriteLine($"Атака №{attackNumber}");

                Console.WriteLine("Отряд 1:");
                ShowPlatoon(_platoon1);
                Console.WriteLine("Отряд 2:");
                ShowPlatoon(_platoon2);

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