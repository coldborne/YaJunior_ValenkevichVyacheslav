namespace WeaponsReport;

public class Program
{
    public static void Main(string[] args)
    {
        SoldierCreator soldierCreator = new SoldierCreator();
        SoldierFactory soldierFactory = new SoldierFactory(soldierCreator);
        Game game = new Game(soldierFactory);

        game.Play();
    }
}