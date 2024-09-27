namespace WeaponsReport;

public class Soldier
{
    private string _weapon;
    private int _serviceTerm;

    public Soldier(string name, string weapon, string rank, int serviceTerm)
    {
        _weapon = weapon;
        _serviceTerm = serviceTerm;

        Name = name;
        Rank = rank;
    }

    public string Name { get; }
    public string Rank { get; }

    public override string ToString()
    {
        return $"Имя: {Name}, Звание: {Rank}, Вооружение: {_weapon}, Срок службы: {_serviceTerm} мес.";
    }
}