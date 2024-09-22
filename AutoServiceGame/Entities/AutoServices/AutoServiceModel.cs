using AutoServiceGame.Entities.Extensions;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities.AutoServices;

public class AutoServiceModel
{
    private List<Part> _parts;

    public AutoServiceModel(List<Part> parts, decimal balance)
    {
        FixedPenalty = 500;

        _parts = parts;
        Balance = balance;
    }

    public AutoServiceModel(decimal balance)
    {
        FixedPenalty = 500;

        _parts = new List<Part>();
        Balance = balance;
    }

    public decimal Balance { get; private set; }
    public decimal FixedPenalty { get; }

    public bool TryAddPart(Part part)
    {
        bool isFound = _parts.Contains(part);

        if (isFound)
        {
            return false;
        }

        _parts.Add(part);
        return true;
    }

    public bool TryGetUnbrokenPart(string name, decimal price, out Part part)
    {
        bool isBroken = false;

        int index = _parts.FindIndex(part => part.Name == name && part.Price == price && part.IsBroken == isBroken);

        if (index >= 0)
        {
            part = _parts[index];
            _parts.RemoveAt(index);
            return true;
        }

        part = null;
        return false;
    }

    public bool TryTopUpBalance(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        Balance += amount;

        return true;
    }

    public bool TryWithdrawBalance(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        decimal finalBalance = Balance - amount;

        if (finalBalance < 0)
        {
            return false;
        }

        Balance = finalBalance;
        return true;
    }

    public List<Part> GetAllParts()
    {
        return _parts.Copy();
    }

    public decimal GetRepairPrice(Part part)
    {
        decimal commissionSize = 0.1m;

        return part.Price * commissionSize;
    }
}