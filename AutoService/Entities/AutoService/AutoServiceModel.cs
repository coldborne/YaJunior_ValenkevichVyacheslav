using AutoService.Entities.Parts;

namespace AutoService.Entities.AutoService;

public class AutoServiceModel
{
    private readonly int _fixedPenalty;

    private Inventory _inventory;

    public AutoServiceModel(decimal balance, Inventory inventory)
    {
        _fixedPenalty = 500;

        _inventory = inventory;
        Balance = balance;
    }

    public decimal Balance { get; private set; }

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

    public bool TryPayPenalty()
    {
        decimal finalBalance = Balance - _fixedPenalty;

        if (finalBalance < 0)
        {
            return false;
        }

        Balance = finalBalance;
        return true;
    }
}