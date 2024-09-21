using AutoServiceGame.Entities.Extensions;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities;

public class Inventory
{
    private List<Item> _parts;

    public Inventory(List<Item> parts)
    {
        _parts = parts;
    }

    public Inventory()
    {
        _parts = new List<Item>();
    }

    public bool TryAddPart(Part part, int quantity)
    {
        bool isFound = Contains(part);

        if (isFound)
        {
            return false;
        }

        Item newPart = new Item(part, quantity);
        _parts.Add(newPart);
        return true;
    }

    public bool TryIncreaseQuantity(Part part, int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        foreach (Item item in _parts)
        {
            if (item.Contains(part))
            {
                return item.TryIncrease(amount);
            }
        }

        return false;
    }

    public bool TryDecreaseQuantity(Part part, int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        foreach (Item item in _parts)
        {
            if (item.Contains(part))
            {
                return item.TryDecrease(amount);
            }
        }

        return false;
    }

    public List<Item> GetAllParts()
    {
        return _parts.Copy<Item>();
    }

    private bool Contains(Part part)
    {
        foreach (Item item in _parts)
        {
            if (item.Contains(part))
            {
                return true;
            }
        }

        return false;
    }
}