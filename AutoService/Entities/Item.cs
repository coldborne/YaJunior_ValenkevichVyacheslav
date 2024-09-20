using AutoService.Entities.Interfaces;

namespace AutoService.Entities;

public class Item<T> : ICopyable<Item<T>> where T : ICopyable<T>
{
    private T _subject;

    public Item(T subject, int count)
    {
        _subject = subject;
        Count = count;
    }

    public Item(T subject)
    {
        _subject = subject;
        Count = 0;
    }

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

    public bool Contains(T subject)
    {
        return _subject.Equals(subject);
    }

    public Item<T> Copy()
    {
        return new Item<T>(_subject.Copy(), Count);
    }
}