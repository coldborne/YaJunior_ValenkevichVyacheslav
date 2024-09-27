namespace DelayDefinition;

public class Stew
{
    public Stew(string name, int productionYear, int shelfYearCount)
    {
        Name = name;
        ProductionYear = productionYear;
        ShelfYearCount = shelfYearCount;
    }

    public string Name { get; }
    public int ProductionYear { get; }
    public int ShelfYearCount { get; }

    public override string ToString()
    {
        return $"Название: {Name}, год производства: {ProductionYear}, срок годности в годах: {ShelfYearCount}";
    }
}