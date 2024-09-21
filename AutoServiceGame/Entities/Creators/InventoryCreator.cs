using AutoServiceGame.Entities.Constants;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities.Creators;

public class InventoryCreator
{
    private Random _random = new Random();

    public Inventory CreateInventory()
    {
        Inventory inventory = new Inventory();
        int minPartsCount = 1;
        int maxPartsCount = 10;

        foreach (Part part in PartsCatalog.GetAvailableParts())
        {
            int quantity = _random.Next(minPartsCount, maxPartsCount + 1);

            inventory.TryAddPart(part, quantity);
        }

        return inventory;
    }
}