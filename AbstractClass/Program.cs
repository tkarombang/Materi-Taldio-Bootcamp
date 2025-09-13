using System;
using System.Drawing;
namespace AbstractClass
{
  abstract class Shape
  {
    protected string Name;
    protected string Color;

    public Shape(string name, string color)
    {
      this.Name = name;
      this.Color = color;
    }


    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();


    public virtual void DisplayInfo()
    {
      Console.WriteLine($"Shape: {Name}");
      Console.WriteLine($"Warna: {Color}");
      Console.WriteLine($"Area: {CalculateArea}");
      Console.WriteLine($"Perimeter: {CalculatePerimeter}");
    }

    public void PrintShapeType()
    {
      Console.WriteLine($"Ini adlaah {Name}");
    }
  }


  class Rectangle : Shape
  {
    private double Width;
    private double Height;

    public Rectangle(double width, double height, string color) : base("Persegi Panjang", color)
    {
      this.Width = width;
      this.Height = height;
    }


    public override double CalculateArea()
    {
      return Width * Height;
    }

    public override double CalculatePerimeter()
    {
      return 2 * (Width * Height);
    }


    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"Lebar: {Width}, Tinggi: {Height}");
    }
  }


  class Circle : Shape
  {
    private double Radius;
    private const double PI = 3.1459;

    public Circle(double radius, string color) : base("Lingkaran", color)
    {
      this.Radius = radius;
    }

    public override double CalculateArea()
    {
      return PI * Radius * Radius;
    }

    public override double CalculatePerimeter()
    {
      return 2 * PI * Radius;
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"Jari-jari: {Radius}");
    }
  }





  class Triangle : Shape
  {
    private double Side1, Side2, Side3;

    public Triangle(double side1, double side2, double side3, string color) : base("Segitiga", color)
    {
      this.Side1 = side1;
      this.Side2 = side2;
      this.Side3 = side3;
    }

    public override double CalculateArea()
    {
      double s = (Side1 + Side2 + Side3) / 2;
      return Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
    }

    public override double CalculatePerimeter()
    {
      return Side1 + Side2 + Side3;
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"Sisi: {Side1}, {Side2}, {Side3}");
    }
  }






  // ABSTRACT CLASS UNTUK BENTUK 3D
  abstract class Shape3D : Shape
  {
    protected double Height;

    public Shape3D(string name, string color, double height) : base(name, color)
    {
      this.Height = height;
    }


    public abstract double CalcoulateVolume();


    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"Volume: {CalcoulateVolume():F2}");
      Console.WriteLine($"Tinggi {Height}");
    }
  }


  class Cylinder : Shape3D
  {
    private double Radius;
    private const double PI = 3.14159;

    public Cylinder(double radius, double height, string color) : base("Silinder", color, height)
    {
      this.Radius = radius;
    }

    public override double CalculateArea()
    {
      return 2 * PI * Radius * (Radius + Height);
    }

    public override double CalculatePerimeter()
    {
      return 2 * PI * Radius;
    }

    public override double CalcoulateVolume()
    {
      return PI * Radius * Radius * Height;
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"Jari-jari: {Radius}");
    }
  }





  class ShapeCalculator
  {
    public static void CalculateTotalArea(Shape[] shapes)
    {
      double totalArea = 0;

      Console.WriteLine("\n====MENGHITUNG TOTAL LUAS=====");
      foreach (Shape shape in shapes)
      {
        double area = shape.CalculateArea();
        totalArea += area;
        Console.WriteLine($"{shape.GetType().Name}: {area:F2}");
      }

      Console.WriteLine($"Total Luas: {totalArea:F2}");
    }
  }





  class Program
  {
    public static void Main(string[] args)
    {

      // TIDAK DAPAT MENGINSTANSIASI ABSTRACT CLASS
      // Shape shape = new shape(); // ini akan menyebabkan compile error
      Shape[] shapes = {
        new Rectangle(5, 3, "Biru"),
        new Circle(4, "Black-White"),
        new Triangle(3, 5, 5, "Black"),
        new Cylinder(3, 5, "Purple"),
      };


      Console.WriteLine("=======INFORMASI BENTUK======");
      foreach (Shape shape in shapes)
      {
        shape.DisplayInfo();
        shape.PrintShapeType();
        Console.WriteLine();
      }


      ShapeCalculator.CalculateTotalArea(shapes);
      Console.ReadLine();


    }

  }


}


