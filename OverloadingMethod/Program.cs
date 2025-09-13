using System;
namespace OverloadingMethod
{
  
  class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("=== MATH UTILS TEST ===");
      Console.WriteLine($"Circle area (radius 5): {MathUtils.CalculateCirclePerimeter(5):F2}");
      Console.WriteLine($"Circle Perimeter (radius 5): {MathUtils.CalculateCirclePerimeter(5):F2}");

      Console.WriteLine("\n === BANK ACCOUNT TEST ===");
      BankAccount.DisplayBankInfo();

      BankAccount account1 = new BankAccount("Muh Ammad", 1000);
      BankAccount account2 = new BankAccount("Az War", 2000);
      BankAccount account5 = new BankAccount("Az War", 1500);


      BankAccount.DisplayBankInfo();

      account1.DisplayAccountInfo();
      account1.Deposit(500);
      account1.ApplyInterest();

      Console.WriteLine("\n==== METHOD OVERLOADING TEST ====");
      Console.WriteLine($"Add(5, 10): {Calculator.Add(5, 10)}");
      Console.WriteLine($"Add(5, 10, 15): {Calculator.Add(5, 10, 15)}");
      Console.WriteLine($"Add(5.5, 10.5): {Calculator.Add(5.5, 10.5)}");
      Console.WriteLine($"Add(1, 2, 3, 4, 5): {Calculator.Add(1, 2, 3, 4, 5)}");

      Console.WriteLine($"Multiply(4, 5): {Calculator.Multiply(4, 5)}");
      Console.WriteLine($"Multiply(4.5, 2.5): {Calculator.Multiply(4.5, 2.5)}");
      Console.WriteLine($"Multiply(2, 3, 4): {Calculator.Multiply(2, 3, 4)}");

      Console.WriteLine(Calculator.ConvertToString(42));
      Console.WriteLine(Calculator.ConvertToString(3.14159));
      Console.WriteLine(Calculator.ConvertToString(true));


      Console.ReadLine();



    }
  }
}