using System;
namespace OverloadingMethod
{
class BankAccount
  {
    // STATIC FIELDS
    private static int nextAccountNumber = 1000;
    private static double interestRate = 0.03;
    private static int totalAccount = 0;

    // INSTANCE FIELDS
    private int Accountnumber;
    private string HolderName;
    private double Balance;


    static BankAccount()
    {
      Console.WriteLine("Bank System initialized");
      nextAccountNumber = 1000;
      interestRate = 0.03;
    }


    // INSTANCE CONSTRUCTOR
    public BankAccount(string holderName, double initialBalance)
    {
      Accountnumber = nextAccountNumber++;
      this.HolderName = holderName;
      Balance = initialBalance;
      totalAccount++;
    }

    // STATIC METHOD
    public static void DisplayBankInfo()
    {
      Console.WriteLine($"Total Accounts: {totalAccount}");
      Console.WriteLine($"Current Interest Rate: {interestRate * 100:F1}%");
      Console.WriteLine($"Next Account Number: {nextAccountNumber}");
    }

    public static double CalculateInterest(double principal, int year)
    {
      return principal * interestRate * year;
    }


    // INSTANCE METHODS
    public void Deposit(double amount)
    {
      Balance += amount;
      Console.WriteLine($"Deposited {amount:C}. New Balance: {Balance:C}");
    }

    public void ApplyInterest()
    {
      double interest = Balance * interestRate;
      Balance += interest;
      Console.WriteLine($"Interest Applied: {interest:C}, New Balance: {Balance:C}");
    }

    public void DisplayAccountInfo()
    {
      DisplayBankInfo();
      CalculateInterest(3000, 2);
      Console.WriteLine($"Account: {Accountnumber}, Holder Name: {HolderName}, Balance: {Balance:C}");
    }
  }
}