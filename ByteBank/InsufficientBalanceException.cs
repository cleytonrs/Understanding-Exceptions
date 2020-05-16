using System;

namespace ByteBank
{
    public class InsufficientBalanceException : FinancialOperationException
    {
        public double BankBalance { get; }
        public double WithdrawalAmount { get; }

        public InsufficientBalanceException()
        {
        }

        public InsufficientBalanceException(string message) : base(message)
        {
        }

        public InsufficientBalanceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InsufficientBalanceException(double bankBalance, double withdrawalAmount)
            : this("Attempted to withdraw the amount of " + withdrawalAmount + " in an account with a bank balance of " + bankBalance)
        {
            BankBalance = bankBalance;
            WithdrawalAmount = withdrawalAmount;
        }
    }
}