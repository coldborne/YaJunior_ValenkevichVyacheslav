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
        List<Item> parts = new List<Item>();

        foreach (Part part in PartsCatalog.GetAvailableParts())
        {
            int quantity = _random.Next(minPartsCount, maxPartsCount + 1);

            Item item = new Item(part, quantity);
            parts.Add(item);
        }

        AutoServiceModel autoServiceModel = new AutoServiceModel(balance);
        AutoServiceView autoServiceView = new AutoServiceView();

        return new AutoService(autoServiceModel, autoServiceView);
    }
}