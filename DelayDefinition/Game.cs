namespace DelayDefinition;

public class Game
{
    private List<Stew> _stews;

    private StewFactory _stewFactory;
    private Random _random;

    public Game(StewFactory stewFactory)
    {
        _stews = new List<Stew>();
        _stewFactory = stewFactory;
        _random = new Random();
    }

    public void Play()
    {
        int minStewCount = 10;
        int maxStewCount = 50;
        int stewCount = _random.Next(minStewCount, maxStewCount + 1);

        _stews = _stewFactory.Create(stewCount);

        ShowStews(_stews, "Все банки тушенки:");

        int currentYear = DateTime.Today.Year;

        List<Stew> expiredStews =
            _stews.Where(stew => stew.ProductionYear + stew.ShelfYearCount < currentYear).ToList();

        Console.WriteLine();
        ShowStews(expiredStews, "Просроченные банки тушенки:");
    }

    private void ShowStews(List<Stew> stews, string message)
    {
        Console.WriteLine(message);

        foreach (Stew stew in stews)
        {
            Console.WriteLine(stew);
        }
    }
}