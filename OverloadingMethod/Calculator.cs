using System;
namespace OverloadingMethod
{
  class Calculator
  {
    public static int Add(int a, int b)
    {
      Console.WriteLine("Adding two integer");
      return a + b;
    }

    public static int Add(int a, int b, int c)
    {
      Console.WriteLine("Adding three integers");
      return a + b + c;
    }

    public static double Add(double a, double b)
    {
      Console.WriteLine("Adding two Doubles");
      return a + b;
    }

    public static int Add(params int[] numbers)
    {
      Console.WriteLine($"Adding array of {numbers.Length} integers");
      int sum = 0;
      foreach (int num in numbers)
      {
        sum += num;
      }
      return sum;
    }

    public static int Multiply(int a, int b)
    {
      return a * b;
    }

    public static double Multiply(double a, double b)
    {
      return a * b;
    }

    public static int Multiply(int a, int b, int c)
    {
      return a * b * c;
    }

    public static string ConvertToString(int number)
    {
      return $"Integer: {number}";
    }

    public static string ConvertToString(double number)
    {
      return $"Double: {number}";
    }
    public static string ConvertToString(bool number)
    {
      return $"Boolean: {number}";
    }
  }
}