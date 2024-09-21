using AutoServiceGame.Entities.Interfaces;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities;

public class Item : ICopyable<Item>
{
    private Part _part;

    public Item(Part part, int count)
    {
        _part = part;
        Count = count;
    }

    public Item(Part part)
    {
        _part = part;
        Count = 1;
    }

    public string Name => _part.Name;
    public int Count { get; private set; }

    public bool TryIncrease(int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        if (Count + amount <= int.MaxValue)
        {
            Count += amount;
            return true;
        }

        return false;
    }

    public bool TryDecrease(int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        if (Count - amount >= 0)
        {
            Count -= amount;
            return true;
        }

        return false;
    }

    public bool Contains(Part subject)
    {
        return _part.Equals(subject);
    }

    public Item Copy()
    {
        return new Item(_part.Copy(), Count);
    }
}