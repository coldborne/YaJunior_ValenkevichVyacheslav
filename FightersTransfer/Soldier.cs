namespace FightersTransfer;

public class Soldier
{
    private string _weapon;
    private int _serviceTerm;

    public Soldier(string name, string surname, string weapon, string rank, int serviceTerm)
    {
        _weapon = weapon;
        _serviceTerm = serviceTerm;

        Name = name;
        Surname = surname;
        Rank = rank;
    }

    public string Name { get; }
    public string Surname { get; }
    public string Rank { get; }

    public override string ToString()
    {
        return
            $"Имя и фамилия: {Name} {Surname}, Звание: {Rank}, Вооружение: {_weapon}, Срок службы: {_serviceTerm} мес.";
    }
}