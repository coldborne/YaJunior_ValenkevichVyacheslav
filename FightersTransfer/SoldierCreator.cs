namespace FightersTransfer;

public class SoldierCreator
{
    private Random _random;

    private List<string> _names;
    private List<string> _surnames;
    private List<string> _weapons;
    private List<string> _ranks;

    public SoldierCreator()
    {
        _random = new Random();

        _names = new List<string>
        {
            "Алексей", "Борис", "Виктор", "Геннадий", "Дмитрий",
            "Евгений", "Иван", "Константин", "Леонид", "Михаил",
            "Николай", "Олег", "Павел", "Роман", "Сергей"
        };

        _surnames = new List<string>
        {
            "Борисов", "Быков", "Сидоров", "Баранов", "Соколов",
            "Попов", "Белов", "Козлов", "Новиков", "Морозов",
            "Волков", "Соловьёв", "Беляев", "Буров", "Павлов"
        };

        _weapons = new List<string>
        {
            "Автомат АК-74", "Снайперская винтовка СВД", "Пистолет Макарова",
            "Ручной пулемет РПК", "Гранатомет РПГ-7", "Пулемет ПКМ",
            "Штурмовая винтовка АН-94", "Граната Ф-1", "Пистолет Стечкина",
            "Ракетный комплекс Игла"
        };

        _ranks = new List<string>
        {
            "Рядовой", "Ефрейтор", "Младший сержант", "Сержант",
            "Старший сержант", "Старшина", "Прапорщик", "Старший прапорщик",
            "Младший лейтенант", "Лейтенант"
        };
    }

    public Soldier Create()
    {
        string name = _names[_random.Next(_names.Count)];
        string surname = _surnames[_random.Next(_surnames.Count)];
        string weapon = _weapons[_random.Next(_weapons.Count)];
        string rank = _ranks[_random.Next(_ranks.Count)];

        int minServiceTerm = 1;
        int maxServiceTerm = 24;
        int serviceTerm = _random.Next(minServiceTerm, maxServiceTerm + 1);

        return new Soldier(name, surname, weapon, rank, serviceTerm);
    }
}