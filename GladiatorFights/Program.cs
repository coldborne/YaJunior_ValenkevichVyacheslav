using System.Collections.Generic;
using GladiatorFights.Entities;
using GladiatorFights.Entities.Fighters;
using GladiatorFights.Entities.Stats;

namespace GladiatorFights
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Fighter mage = new Mage("Чародей", new Health(100), new Damage(15), new Mana(30));
            Fighter paladin = new Paladin("Воин", new Health(120), new Damage(10));
            Fighter barbarian = new Barbarian("Варвар", new Health(150), new Damage(20));
            Fighter necromancer = new Necromancer("Некромант", new Health(80), new Damage(30));
            Fighter thief = new Thief("Вор", new Health(100), new Damage(15));
            
            List<Fighter> fighters = new List<Fighter>() {mage, paladin, barbarian, necromancer, thief};

            Arena arena = new Arena(fighters);
            arena.Fight();
        }
    }
}