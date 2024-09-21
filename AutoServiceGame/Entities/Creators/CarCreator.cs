using AutoServiceGame.Entities.Cars;
using AutoServiceGame.Entities.Constants;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities.Creators;

public class CarCreator
{
    private List<string> _carModels = new List<string>
    {
        "Model A",
        "Model B",
        "Model C",
        "Model D"
    };

    private Random _random = new Random();

    public Car CreateCar()
    {
        string model = _carModels[_random.Next(_carModels.Count)];

        int minPartAmount = 3;
        int maxPartAmount = PartsCatalog.Count;

        int partsAmount = _random.Next(minPartAmount, maxPartAmount + 1);

        List<Part> selectedParts = new List<Part>();

        List<Part> partsPool = PartsCatalog.GetAvailableParts();

        for (int partNumber = 1; partNumber < partsAmount; partNumber++)
        {
            int partIndex = _random.Next(partsPool.Count);
            Part part = partsPool[partIndex];

            partsPool.RemoveAt(partIndex);

            selectedParts.Add(part.Copy());
        }

        int minBrokenPartAmount = 1;
        int maxBrokenPartAmount = selectedParts.Count - 1;

        int brokenPartsCount = _random.Next(minBrokenPartAmount, maxBrokenPartAmount + 1);

        selectedParts = selectedParts.OrderBy(part => _random.Next()).ToList();

        for (int partIndex = 0; partIndex < brokenPartsCount; partIndex++)
        {
            selectedParts[partIndex].TryBreak();
        }

        return new Car(model, selectedParts);
    }
}