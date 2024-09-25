namespace CriminalSearching;

public class Criminal
{
    public Criminal(string fullName, string nationality, bool isUnderArrest, int height, int weight)
    {
        FullName = fullName;
        Nationality = nationality;
        IsUnderArrest = isUnderArrest;
        Height = height;
        Weight = weight;
    }

    public string FullName { get; }
    public string Nationality { get; }

    public bool IsUnderArrest { get; private set; }

    public int Height { get; }
    public int Weight { get; }

    public override string ToString()
    {
        return
            $"Имя: {FullName}, национальность: {Nationality}, под арестом: {IsUnderArrest}, рост: {Height}, вес: {Weight}";
    }
}