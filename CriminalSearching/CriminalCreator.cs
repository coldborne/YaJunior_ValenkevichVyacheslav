namespace CriminalSearching;

public class CriminalCreator
{
    private Random _random;
    private List<string> _firstNames;
    private List<string> _lastNames;
    private List<string> _nationalities;

    public CriminalCreator()
    {
        _random = new Random();

        _firstNames = new List<string>
        {
            "Иван", "Алексей", "Дмитрий", "Сергей", "Михаил",
            "Андрей", "Николай", "Павел", "Владимир", "Егор"
        };

        _lastNames = new List<string>
        {
            "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов",
            "Попов", "Лебедев", "Козлов", "Новиков", "Морозов"
        };

        _nationalities = new List<string>
        {
            "Русский", "Украинец", "Белорус", "Казах", "Армянин",
            "Грузин", "Узбек", "Таджик", "Киргиз", "Молдаванин"
        };
    }

    public Criminal CreateRandomCriminal()
    {
        string fullName = GenerateRandomFullName();
        string nationality = GenerateRandomNationality();

        int freeStateNumber = 0;
        int underArrestStateNumber = 1;
        int criminalStateNumber = _random.Next(freeStateNumber, underArrestStateNumber + 1);
        bool isUnderArrest = criminalStateNumber == underArrestStateNumber;

        int minHeight = 170;
        int maxHeight = 190;
        int height = _random.Next(minHeight, maxHeight + 1);

        int minWeight = 70;
        int maxWeight = 100;
        int weight = _random.Next(minWeight, maxWeight + 1);

        return new Criminal(fullName, nationality, isUnderArrest, height, weight);
    }

    public List<Criminal> CreateRandomCriminals(int count)
    {
        List<Criminal> criminals = new List<Criminal>();

        for (int i = 1; i <= count; i++)
        {
            criminals.Add(CreateRandomCriminal());
        }

        return criminals;
    }

    private string GenerateRandomFullName()
    {
        string firstName = _firstNames[_random.Next(_firstNames.Count)];
        string lastName = _lastNames[_random.Next(_lastNames.Count)];
        return $"{firstName} {lastName}";
    }

    private string GenerateRandomNationality()
    {
        return _nationalities[_random.Next(_nationalities.Count)];
    }
}