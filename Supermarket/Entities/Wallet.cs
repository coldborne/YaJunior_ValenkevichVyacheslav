using System;

namespace Supermarket
{
    public class Wallet
    {
        public Wallet(int startBalance)
        {
            Balance = startBalance;
        }

        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма внесения должна быть положительной");
            }

            Balance += amount;
        }

        public bool TryWithdraw(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма снятия должна быть положительной");
            }

            if (amount > Balance)
            {
                return false;
            }

            Balance -= amount;
            return true;
        }
    }
}