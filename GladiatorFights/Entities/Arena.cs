using System;
using System.Collections.Generic;
using GladiatorFights.Entities.Fighters;

namespace GladiatorFights.Entities
{
    public class Arena
    {
        private List<Fighter> _availableFighters;

        public Arena(List<Fighter> availableFighters)
        {
            _availableFighters = availableFighters;
        }

        public void Fight()
        {
            Random random = new Random();

            int attackerIndex = random.Next(_availableFighters.Count);
            Fighter firstFighter = _availableFighters[attackerIndex].Copy();

            int targetIndex = random.Next(_availableFighters.Count);
            Fighter secondFighter = _availableFighters[targetIndex].Copy();

            Console.WriteLine("Бой начался!");
            Console.WriteLine();

            while (firstFighter.Health > 0 && secondFighter.Health > 0)
            {
                firstFighter.Attack(secondFighter);

                if (secondFighter.Health <= 0)
                {
                    Console.WriteLine($"{secondFighter.Name} пал в бою.");
                }
                else
                {
                    secondFighter.Attack(firstFighter);

                    if (firstFighter.Health <= 0)
                    {
                        Console.WriteLine($"{firstFighter.Name} пал в бою.");
                    }
                }

                Console.WriteLine("Статус бойцов:");

                Console.WriteLine(firstFighter);
                Console.WriteLine(secondFighter);

                Console.WriteLine("---------------------------------------------------");
            }

            if (firstFighter.Health > 0)
            {
                Console.WriteLine($"Победитель: {firstFighter.Name} с {firstFighter.Health} оставшимися жизнями!");
            }
            else
            {
                if (secondFighter.Health > 0)
                {
                    Console.WriteLine(
                        $"Победитель: {secondFighter.Name} с {secondFighter.Health} оставшимися жизнями!");
                }
                else
                {
                    Console.WriteLine("Все бойцы пали в бою.");
                }
            }
        }
    }
}