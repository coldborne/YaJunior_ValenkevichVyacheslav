namespace WeaponsReport;

public class Game
{
    private List<Soldier> _soldiers;

    private SoldierFactory _soldierFactory;

    public Game(SoldierFactory soldierFactory)
    {
        _soldiers = new List<Soldier>();
        _soldierFactory = soldierFactory;
    }

    public void Play()
    {
        int soldierCount = 30;
        _soldiers = _soldierFactory.Create(soldierCount);

        Console.WriteLine("Все солдаты:");

        foreach (Soldier soldier in _soldiers)
        {
            Console.WriteLine(soldier);
        }

        var soldiersInfo =
            _soldiers.Select(soldier => new { Name = soldier.Name, Rank = soldier.Rank });

        Console.WriteLine("\nОсновная информация о солдатах:");

        foreach (var soldierInfo in soldiersInfo)
        {
            Console.WriteLine($"Имя: {soldierInfo.Name}, ранг: {soldierInfo.Rank}");
        }
    }
}