namespace DelayDefinition;

public class Program
{
    public static void Main(string[] args)
    {
        StewCreator creator = new StewCreator();
        int stewCount = 30;

        List<Stew> stews = creator.CreateRandomStews(stewCount);

        Console.WriteLine("Все банки тушенки:");

        foreach (Stew stew in stews)
        {
            Console.WriteLine(stew);
        }

        int currentYear = DateTime.Today.Year;

        List<Stew> expiredStews = stews.Where(stew => stew.ProductionYear + stew.ShelfYearCount < currentYear).ToList();

        Console.WriteLine("\nПросроченные банки тушенки:");

        foreach (Stew stew in expiredStews)
        {
            Console.WriteLine(stew);
        }
    }
}