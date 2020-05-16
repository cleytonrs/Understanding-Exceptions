using System;

namespace ByteBank
{
    public class CurrentAccount
    {
        private static int OperationFee;

        public static int TotalAccountsCreated { get; private set; }
        public Customer Holder { get; set; }
        public int WithdrawalCounterNotAllowed { get; private set; }
        public int TransferCounterNotAllowed { get; private set; }
        public int AccountNumber { get; }
        public int AgencyNumber { get; }
        private double _bankBalance = 100;

        public double BankBalance
        {
            get
            {
                return _bankBalance;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                _bankBalance = value;
            }
        }

        public CurrentAccount(int agencyNumber, int accountNumber)
        {
            AccountNumber = accountNumber;
            AgencyNumber = agencyNumber;

            if (AccountNumber <= 0)
            {
                throw new ArgumentException("The account number argument must be greater than 0.", nameof(accountNumber));
            }
            if (AgencyNumber <= 0)
            {
                throw new ArgumentException("The agency argument must be greater than 0.", nameof(agencyNumber));
            }

            TotalAccountsCreated++;
            OperationFee = 30 / TotalAccountsCreated;
        }

        public void WithdrawalAmount(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid withdrawal amount.", nameof(value));
            }

            if (_bankBalance < value)
            {
                WithdrawalCounterNotAllowed++;
                throw new InsufficientBalanceException(BankBalance, value);
            }

            _bankBalance -= value;
        }


        public void BankDeposit(double value)
        {
            _bankBalance += value;
        }

        public void BankTransfer(double value, CurrentAccount targetAccount)
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid transfer amount.", nameof(value));
            }

            try
            {
                WithdrawalAmount(value);
            }
            catch (InsufficientBalanceException e)
            {
                TransferCounterNotAllowed++;
                throw new FinancialOperationException("Operation not performed.", e);
            }

            targetAccount.BankDeposit(value);
        }
    }
}
