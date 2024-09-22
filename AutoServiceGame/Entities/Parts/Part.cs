using AutoServiceGame.Entities.Interfaces;

namespace AutoServiceGame.Entities.Parts;

public class Part : IEquatable<Part>, IComparable<Part>, ICopyable<Part>
{
    public Part(string name, decimal price, bool isBroken = false)
    {
        Name = name;
        Price = price;
        IsBroken = isBroken;
    }

    public string Name { get; }
    public decimal Price { get; }
    public bool IsBroken { get; private set; }

    public bool TryBreak()
    {
        if (IsBroken == false)
        {
            IsBroken = !IsBroken;
            return true;
        }

        return false;
    }

    public bool Equals(Part? other)
    {
        if (ReferenceEquals(null, other))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Name == other.Name && Price == other.Price;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (obj.GetType() != GetType())
            return false;

        return Equals((Part)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Price);
    }

    public Part Copy()
    {
        return new Part(Name, Price, IsBroken);
    }

    public int CompareTo(Part? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (other is null)
        {
            return 1;
        }

        int nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);

        if (nameComparison != 0)
        {
            return nameComparison;
        }

        int priceComparison = Price.CompareTo(other.Price);

        if (priceComparison != 0)
        {
            return priceComparison;
        }

        return IsBroken.CompareTo(other.IsBroken);
    }
}