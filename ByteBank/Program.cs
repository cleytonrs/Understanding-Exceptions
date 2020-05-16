using System;

namespace ByteBank
{
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\nInnerException method\n");
                InnerExceptionTest();
                Console.WriteLine("\n");

                Console.WriteLine("\nMainMethod\n");
                MainMethod();
                Console.WriteLine("\n");

                Console.WriteLine("\nLoading accounts\n");
                LoadingAccounts();
            }
            catch (Exception)
            {
                Console.WriteLine("\nException caught in the main method");
            }

            Console.WriteLine("\nClick the enter key to exit");
            Console.ReadLine();
        }

        private static void LoadingAccounts()
        {
            using (FileReader reader = new FileReader("test.txt"))
            {
                reader.ReadNextLine();
            }
        }

        private static void InnerExceptionTest()
        {
            try
            {
                CurrentAccount account1 = new CurrentAccount(45, 125);
                CurrentAccount account2 = new CurrentAccount(43, 127);

                account2.BankTransfer(50, account1);
                account1.WithdrawalAmount(20);

                Console.WriteLine("[Account1] - Agency Number: " + account1.AgencyNumber + " | Account Number: " + account1.AccountNumber + " | Bank Balance R$ " + account1.BankBalance + ",00");
                Console.WriteLine("[Account2] - Agency Number: " + account2.AgencyNumber + " | Account Number: " + account2.AccountNumber + " | Bank Balance R$ " + account2.BankBalance + ",00");
            }
            catch (FinancialOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        // Call chain testing
        // Method -> TestSplitOperation -> SplitOperation
        private static void MainMethod()
        {
            TestSplitOperation(10, 5);
        }

        private static void TestSplitOperation(int number, int divider)
        {
            int result = SplitOperation(number, divider);
            Console.WriteLine("Result of dividing " + number + " by " + divider + " is " + result);
        }

        private static int SplitOperation(int number, int divider)
        {
            try
            {
                return number / divider;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exception with number = " + number + " and divider = " + divider);
                throw;
            }
        }

    }
}
