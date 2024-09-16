using War.Entities;
using War.Entities.Soldiers;
using War.Entities.Stats;

namespace War
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Platoon platoon1 = new Platoon();
            platoon1.AddSoldier(new Rifleman(new Health(100), new Damage(20), new Armor(5)));
            platoon1.AddSoldier(new Sniper(new Health(100), new Damage(15), new Armor(5), 1.5));
            platoon1.AddSoldier(new Grenadier(new Health(100), new Damage(10), new Armor(5)));
            platoon1.AddSoldier(new Flamethrower(new Health(100), new Damage(10), new Armor(5)));
            
            Platoon platoon2 = new Platoon();
            platoon2.AddSoldier(new Rifleman(new Health(100), new Damage(20), new Armor(5)));
            platoon2.AddSoldier(new Sniper(new Health(100), new Damage(15), new Armor(5), 1.5));
            platoon2.AddSoldier(new Grenadier(new Health(100), new Damage(10), new Armor(5)));
            platoon2.AddSoldier(new Flamethrower(new Health(100), new Damage(10), new Armor(5)));
            
            Game game = new Game(platoon1, platoon2);
            game.StartBattle();
        }
    }
}