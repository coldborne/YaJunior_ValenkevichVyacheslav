namespace WeaponsReport;

public class Soldier
{
    public Soldier(string name, string weapon, string rank, int serviceTerm)
    {
        Name = name;
        Weapon = weapon;
        Rank = rank;
        ServiceTerm = serviceTerm;
    }

    public string Name { get; }
    public string Weapon { get; }
    public string Rank { get; }
    public int ServiceTerm { get; }

    public override string ToString()
    {
        return $"Имя: {Name}, Звание: {Rank}, Вооружение: {Weapon}, Срок службы: {ServiceTerm} мес.";
    }
}