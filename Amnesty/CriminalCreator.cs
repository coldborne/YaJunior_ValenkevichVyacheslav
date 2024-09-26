using Amnesty;

namespace CriminalSearching;

public class CriminalCreator
{
    private Random _random;
    private List<string> _firstNames;
    private List<string> _lastNames;
    private List<string> _crimes;

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

        _crimes = new List<string>
        {
            "Антиправительственное", "Вождение в нетрезвом виде", "Разбой", "Производство мемы с хазбиком",
            "Просьба закрыть окно в душном автобусе"
        };
    }

    public Criminal CreateRandomCriminal()
    {
        string fullName = GenerateRandomFullName();
        string crime = GenerateRandomCrime();

        return new Criminal(fullName, crime);
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

    private string GenerateRandomCrime()
    {
        return _crimes[_random.Next(_crimes.Count)];
    }
}