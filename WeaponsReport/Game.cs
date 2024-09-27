using System.Reflection;

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

        ShowSoldiers(_soldiers, "Все солдаты:");

        var soldiersInfo =
            _soldiers.Select(soldier => new { Name = soldier.Name, Rank = soldier.Rank }).ToList();

        Show(soldiersInfo, "\nОсновная информация о солдатах:");
    }

    private void ShowSoldiers(List<Soldier> soldiers, string message)
    {
        Console.WriteLine(message);

        foreach (Soldier soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }

    private void Show<T>(IEnumerable<T> items, string message)
    {
        Console.WriteLine(message);

        char[] splitters = new char[] { ',', ' ' };

        foreach (T item in items)
        {
            PropertyInfo[] properties = item.GetType().GetProperties();
            string itemInfo = String.Empty;

            foreach (var propertyInfo in properties)
            {
                itemInfo += $"{propertyInfo.Name}: {propertyInfo.GetValue(item)}, ";
            }

            Console.WriteLine(itemInfo.TrimEnd(splitters));
        }
    }
}