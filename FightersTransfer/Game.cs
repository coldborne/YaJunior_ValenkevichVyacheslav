namespace FightersTransfer;

public class Game
{
    private Random _random;
    private SoldierFactory _soldierFactory;

    public Game(SoldierFactory soldierFactory)
    {
        _random = new Random();
        _soldierFactory = soldierFactory;
    }

    public void Play()
    {
        int minSoldierCount = 10;
        int maxSoldierCount = 30;

        int firstSquadSoldierCount = _random.Next(minSoldierCount, maxSoldierCount + 1);
        List<Soldier> firstSoldierSquad = _soldierFactory.Create(firstSquadSoldierCount);

        int secondSquadSoldierCount = _random.Next(minSoldierCount, maxSoldierCount + 1);
        List<Soldier> secondSoldierSquad = _soldierFactory.Create(secondSquadSoldierCount);

        ShowSoldiers(firstSoldierSquad, "Солдаты первого отряда:");
        ShowSoldiers(secondSoldierSquad, "Солдаты второго отряда:");

        char firstTransferNameLetter = 'Б';

        List<Soldier> soldiersToTransfer = firstSoldierSquad
            .Where(soldier => soldier.Surname.StartsWith(firstTransferNameLetter)).ToList();

        firstSoldierSquad = firstSoldierSquad.Except(soldiersToTransfer).ToList();
        secondSoldierSquad = secondSoldierSquad.Concat(soldiersToTransfer).ToList();

        ShowSoldiers(firstSoldierSquad, "\nНовые солдаты первого отряда:");
        ShowSoldiers(secondSoldierSquad, "Новые солдаты второго отряда:");
    }

    private void ShowSoldiers(List<Soldier> soldiers, string message)
    {
        Console.WriteLine(message);

        foreach (Soldier soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}