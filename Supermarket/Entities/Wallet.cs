using System;

namespace Supermarket
{
    public class Wallet
    {
        private int _balance;

        public Wallet(int startBalance)
        {
            _balance = startBalance;
        }

        public int Balance => _balance;

        public void Deposit(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма внесения должна быть положительной");
            }

            _balance += amount;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма снятия должна быть положительной");
            }

            if (amount > _balance)
            {
                return false;
            }

            _balance -= amount;
            return true;
        }
    }
}