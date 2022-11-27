using System;

namespace Gladiator_fights
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Arena arena = new Arena();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Доступные бойцы");
            Console.ResetColor();
            
            arena.ShowAllFighters();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Выберите первого бойца из списка:");
            Console.ResetColor();
            
            int selectedFirstFighter = UserUtils.SelectFighter(arena);
            int selectedSecondFighter = UserUtils.SelectFighter(arena);

            var firstFighter = arena.CreateFighter(selectedFirstFighter);

            firstFighter.HealPoints = 1000;
            
            arena.ShowAllFighters();
        }
    }
}