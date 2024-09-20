using AutoServiceGame.Entities.Extensions;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities;

public class Inventory
{
    private List<Item<Part>> _parts;

    public Inventory(List<Item<Part>> parts)
    {
        _parts = parts;
    }

    public Inventory()
    {
        _parts = new List<Item<Part>>();
    }

    public bool TryAddPart(Part part, int quantity)
    {
        bool isFound = Contains(part);

        if (isFound)
        {
            return false;
        }

        Item<Part> newPart = new Item<Part>(part, quantity);
        _parts.Add(newPart);
        return true;
    }

    public bool TryDecreaseQuantity(Part part, int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        foreach (Item<Part> item in _parts)
        {
            if (item.Contains(part))
            {
                return item.TryDecrease(amount);
            }
        }

        return false;
    }

    public List<Item<Part>> GetAllParts()
    {
        return _parts.Copy<Item<Part>>();
    }

    private bool Contains(Part part)
    {
        foreach (Item<Part> item in _parts)
        {
            if (item.Contains(part))
            {
                return true;
            }
        }

        return false;
    }
}