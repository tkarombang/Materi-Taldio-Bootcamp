using System;
namespace Polymorphism
{

  abstract class Animal
  {
    protected string Name;
    protected int Age;

    public Animal(string name, int age)
    {
      this.Name = name;
      this.Age = age;
    }
    public virtual void MakeSound()
    {
      Console.WriteLine("Animal sound");
    }
    public virtual void Move()
    {
      Console.WriteLine($"{Name} Move");
    }
    public virtual void Sleep()
    {
      Console.WriteLine($"{Name} Sleeep");
    }

    public abstract void Eat();

    public virtual void DisplayInfo()
    {
      Console.WriteLine($"Nama: {Name}, Umur: {Age}");
    }
  }

  class Dog : Animal
  {
    private string Bread;

    public Dog(string name, int age, string bread) : base(name, age)
    {
      this.Bread = bread;
    }

    public override void MakeSound()
    {
      Console.WriteLine($"{Name} Guk GUk");
    }

    public override void Move()
    {
      Console.WriteLine($"{Name} Berlari");
    }

    public override void Eat()
    {
      Console.WriteLine($"{Name} Makan makanan Anjing");
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"Ras: {Bread}");
    }

    public void Fetch()
    {
      Console.WriteLine($"{Name} Mengambil Tongkat");
    }
  }


  class Cat : Animal
  {
    private bool IsIndoor;

    public Cat(string name, int age, bool isIndoor) : base(name, age)
    {
      this.IsIndoor = isIndoor;
    }


    public override void MakeSound()
    {
      Console.WriteLine($"{Name} Meaaaw...!");
    }

    public override void Move()
    {
      Console.WriteLine($"{Name} Garuk-garuk");
    }

    public override void Eat()
    {
      Console.WriteLine($"{Name} Makan wiskas");
    }


    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"Kucing Rumahan: {IsIndoor}");
    }

    public void Climb()
    {
      Console.WriteLine($"{Name} Memanjat Pohon");
    }
  }



  class Bird : Animal
  {
    private double Wingspan;

    public Bird(string name, int age, double wingspan) : base(name, age)
    {
      this.Wingspan = wingspan;
    }

    public override void MakeSound()
    {
      Console.WriteLine($"{Name} Berkicau: Cuiiit!!");
    }

    public override void Move()
    {
      Console.WriteLine($"{Name} Terbang Tinggi Di langit");
    }

    public override void Eat()
    {
      Console.WriteLine($"{Name} Makan biji-bijian");
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"Lebar Sayap: {Wingspan} cm");
    }

    public void Fly()
    {
      Console.WriteLine($"{Name} Melayang tinggi...!");
    }

  }





  class Program
  {
    public static void Main(string[] args)
    {

      Animal[] animals = {
        new Dog("Buddy", 3, "Golden Retriever"),
        new Cat("Momoa", 2, true),
        new Bird("Garuda", 5, 180.5),
        new Cat("jang", 2, false),
      };

      Console.WriteLine("=====DEMONSTRASI POLYMORPHISM");

      foreach (Animal animal in animals)
      {
        Console.WriteLine("\n==== Info Hewan ====");
        animal.DisplayInfo();
        animal.MakeSound();
        animal.Move();
        animal.Eat();
        animal.Sleep();
      }


      Console.WriteLine("\n====METHOD KHUSUS TIPE====");
      foreach (Animal animal in animals)
      {
        if (animal is Dog dog)
        {
          dog.Fetch();
        }
        else if (animal is Cat cat)
        {
          cat.Climb();
        }
        else if (animal is Bird bird)
        {
          bird.Fly();
        }
      }

      Console.ReadLine();

    }
  }
}