namespace DelayDefinition;

public class StewCreator
{
    private Random _random;

    private List<string> _names;

    public StewCreator()
    {
        _random = new Random();

        _names = new List<string>
        {
            "БАРС Экстра ГОСТ", "Главпродукт ГОСТ", "Березовский мясоконсервный комбинат", "Батькин резерв ГОСТ",
            "Кронидов ТУ", "Гродфуд", "Село Зелёное ГОСТ", "Совок ГОСТ"
        };
    }

    public Stew CreateRandomStew()
    {
        string name = _names[_random.Next(_names.Count)];

        int minShelfYearCount = 2;
        int maxShelfYearCount = 15;
        int shelfYearCount = _random.Next(minShelfYearCount, maxShelfYearCount + 1);

        int minProductionYear = DateTime.Today.Year - maxShelfYearCount;
        int maxProductionYear = DateTime.Today.Year;
        int productionYear = _random.Next(minProductionYear, maxProductionYear + 1);

        return new Stew(name, productionYear, shelfYearCount);
    }

    public List<Stew> CreateRandomStews(int count)
    {
        List<Stew> patients = new List<Stew>();

        for (int i = 0; i < count; i++)
        {
            patients.Add(CreateRandomStew());
        }

        return patients;
    }
}