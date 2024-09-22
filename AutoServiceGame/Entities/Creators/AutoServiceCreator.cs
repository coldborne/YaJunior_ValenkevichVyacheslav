using AutoServiceGame.Entities.AutoServices;
using AutoServiceGame.Entities.Constants;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities.Creators;

public class AutoServiceCreator
{
    private Random _random;

    public AutoServiceCreator()
    {
        _random = new Random();
    }

    public AutoService CreateAutoService(decimal balance)
    {
        int minPartsCount = 1;
        int maxPartsCount = 10;
        List<Part> parts = new List<Part>();

        foreach (Part part in PartsCatalog.GetAvailableParts())
        {
            int quantity = _random.Next(minPartsCount, maxPartsCount + 1);

            for (int partNumber = 1; partNumber <= quantity; partNumber++)
            {
                parts.Add(part.Copy());
            }
        }
        
        parts = parts.OrderBy(part => _random.Next()).ToList();

        AutoServiceModel autoServiceModel = new AutoServiceModel(parts, balance);
        AutoServiceView autoServiceView = new AutoServiceView();

        return new AutoService(autoServiceModel, autoServiceView);
    }
}