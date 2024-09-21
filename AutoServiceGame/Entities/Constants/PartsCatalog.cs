using AutoServiceGame.Entities.Extensions;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities.Constants;

public static class PartsCatalog
{
    private static readonly List<Part> _availableParts = new List<Part>
    {
        new Part("Двигатель", 50000m),
        new Part("Тормозные колодки", 5000m),
        new Part("Фара", 2500m),
        new Part("Коробка передач", 30000m),
        new Part("Подвеска", 15000m),
        new Part("Глушитель", 8000m),
        new Part("Радиатор", 7000m),
        new Part("Генератор", 6000m),
        new Part("Колесо", 1000m),
    };

    public static int Count => _availableParts.Count;

    public static List<Part> GetAvailableParts() => _availableParts.Copy<Part>();
}