using System;
namespace OverloadingMethod
{
  static class MathUtils
  {
    // static field
    public static readonly double PI = 3.14159265359;

    // STATIC METHOD
    public static double CalculateCircleArea(double radius)
    {
      return PI * radius * radius;
    }

    public static double CalculateCirclePerimeter(double radius)
    {
      return 2 * PI * radius;
    }

    public static double Power(double baseNumber, int exponent)
    {
      double result = 1;
      for (int i = 0; i < exponent; i++)
      {
        result *= baseNumber;
      }
      return result;
    }
  }

}