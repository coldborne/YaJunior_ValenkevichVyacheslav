using AutoServiceGame.Entities.Interfaces;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities;

public class Item : ICopyable<Item>
{
    private Part _subject;

    public Item(Part subject, int count)
    {
        _subject = subject;
        Count = count;
    }

    public Item(Part subject)
    {
        _subject = subject;
        Count = 1;
    }
    
    public string Name => _subject.Name;
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
        return _subject.Equals(subject);
    }

    public Item Copy()
    {
        return new Item(_subject.Copy(), Count);
    }
}