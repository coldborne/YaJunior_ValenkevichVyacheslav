namespace FightersTransfer;

public class SoldierFactory
{
    private SoldierCreator _soldierCreator;

    public SoldierFactory(SoldierCreator soldierCreator)
    {
        _soldierCreator = soldierCreator;
    }

    public List<Soldier> Create(int count)
    {
        List<Soldier> soldiers = new List<Soldier>();

        for (int i = 0; i < count; i++)
        {
            soldiers.Add(_soldierCreator.Create());
        }

        return soldiers;
    }
}