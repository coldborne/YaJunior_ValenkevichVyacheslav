namespace Amnesty;

public class Criminal
{
    public Criminal(string fullName, string crime)
    {
        FullName = fullName;
        Crime = crime;
    }

    public string FullName { get; }
    public string Crime { get; }

    public override string ToString()
    {
        return
            $"Имя: {FullName}, национальность: {Crime}";
    }
}