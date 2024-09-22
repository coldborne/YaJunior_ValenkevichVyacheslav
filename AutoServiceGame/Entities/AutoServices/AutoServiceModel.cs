using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities.AutoServices;

public class AutoServiceModel
{
    private List<Item> _parts;

    public AutoServiceModel(List<Item> parts, decimal balance)
    {
        FixedPenalty = 500;

        _parts = parts;
        Balance = balance;
    }

    public AutoServiceModel(decimal balance)
    {
        FixedPenalty = 500;

        _parts = new List<Item>();
        Balance = balance;
    }

    public decimal Balance { get; private set; }
    public decimal FixedPenalty { get; }

    public bool TryIncreasePartQuantity(Part part)
    {
        int quantity = 1;
        return _inventory.TryIncreaseQuantity(part, quantity);
    }

    public bool TryDecreasePartQuantity(Part part)
    {
        int quantity = 1;
        return _inventory.TryDecreaseQuantity(part, quantity);
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

    public List<Item> GetAllParts()
    {
        return _parts.Copy<Item>();
    }

    public decimal GetRepairPrice(Part part)
    {
        decimal commissionSize = 0.1m;

        return part.Price * commissionSize;
    }
}