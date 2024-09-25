namespace CriminalSearching;

public class CriminalCreator
{
    private Random random;
    private List<string> firstNames;
    private List<string> lastNames;
    private List<string> nationalities;

    public CriminalCreator()
    {
        random = new Random();

        firstNames = new List<string>
        {
            "Иван", "Алексей", "Дмитрий", "Сергей", "Михаил",
            "Андрей", "Николай", "Павел", "Владимир", "Егор"
        };

        lastNames = new List<string>
        {
            "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов",
            "Попов", "Лебедев", "Козлов", "Новиков", "Морозов"
        };

        nationalities = new List<string>
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
        int criminalStateNumber = random.Next(freeStateNumber, underArrestStateNumber + 1);
        bool isUnderArrest = criminalStateNumber == underArrestStateNumber;

        int minHeight = 170;
        int maxHeight = 190;
        int height = random.Next(minHeight, maxHeight + 1);

        int minWeight = 70;
        int maxWeight = 100;
        int weight = random.Next(minWeight, maxWeight + 1);

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
        string firstName = firstNames[random.Next(firstNames.Count)];
        string lastName = lastNames[random.Next(lastNames.Count)];
        return $"{firstName} {lastName}";
    }

    private string GenerateRandomNationality()
    {
        return nationalities[random.Next(nationalities.Count)];
    }
}