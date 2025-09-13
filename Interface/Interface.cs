using System;
using System.Collections.Generic;
namespace Interface
{
  interface IFlyable
  {
    void Fly();
    double GetFlightSpeed();
    void Land();
  }


  interface ISwimmable
  {
    void Swim();
    double GetSwimSpeed();
    void Dive();
  }

  interface IDrivable
  {
    void StartEngine();
    void StopEngine();
    void Drive();
    double GetMaxSpeed();
  }

  interface IMaintanable
  {
    void PerforMaintenance();
    DateTime GetLastMaintenanceDate();
    bool NeedsMaintanance();
  }


  abstract class Vehicle
  {
    protected string Model;
    protected int Year;
    protected bool isRunning;

    public Vehicle(string model, int year)
    {
      this.Model = model;
      this.Year = year;
      this.isRunning = false;
    }

    public virtual void DisplayInfo()
    {
      Console.WriteLine($"Model: {Model}, Tahun: {Year}, Berjalan: {isRunning}");
    }
  }


  class Airplane : Vehicle, IFlyable, IMaintanable
  {
    private double FlightSpeed;
    private int FlightHours;
    private DateTime LastMaintanance;

    public Airplane(string model, int year, double flightspeed) : base (model, year)
    {
      this.FlightSpeed = flightspeed;
      this.LastMaintanance = DateTime.Now.AddMonths(-2);
      this.FlightHours = 0;
    }

    public void Fly()
    {
      if (isRunning)
      {
        Console.WriteLine($"{Model} Tidak dapat terbang -mesin  belum dinyalakan");
        return;
      }

      Console.WriteLine($"{Model} Sedang terbang dengan kecepatan {FlightSpeed} km/h");
      FlightHours++;
    }


    public double GetFlightSpeed()
    {
      return FlightSpeed;
    }


    public void Land()
    {
      Console.WriteLine($"{Model} Sedang Mendarat dengan Aman");
    }

    public void PerforMaintenance()
    {
      LastMaintanance = DateTime.Now;
      FlightHours = 0;
      Console.WriteLine($"{Model} Perawatan selesai pada {LastMaintanance:yyyy-MM-dd}");
    }

    public DateTime GetLastMaintenanceDate()
    {
      return LastMaintanance;
    }

    public bool NeedsMaintanance()
    {
      return FlightHours > 100 || DateTime.Now.Subtract(LastMaintanance).Days > 90;
    }

    public void StartEngine()
    {
      isRunning = true;
      Console.WriteLine($"{Model} Mesin Dinyalakan");
    }

    public void StopEngine()
    {
      isRunning = false;
      Console.WriteLine($"{Model} Mesin Dimatikan");
    }
  }

  class Car : Vehicle, IDrivable, IMaintanable
  {
    private double MaxSpeed;
    private int Mileage;
    private DateTime LastMaintanance;

    public Car(string model, int year, double maxSpeed) : base(model, year)
    {
      this.MaxSpeed = maxSpeed;
      this.Mileage = 0;
      this.LastMaintanance = DateTime.Now;
    }

    public void StartEngine()
    {
      isRunning = true;
      Console.WriteLine($"{Model} mesin dinyalakan");
    }

    public void StopEngine()
    {
      isRunning = false;
      Console.WriteLine($"{Model} mesin dimatikan");
    }

    public void Drive()
    {
      if (!isRunning)
      {
        Console.WriteLine($"{Model} Tidak dapat dikemudikan - mesin belum On!");
      }
      Console.WriteLine($"{Model} sedang Dikemudikan");
      Mileage += 10;
    }


    public double GetMaxSpeed()
    {
      return MaxSpeed;
    }


    public void PerforMaintenance()
    {
      LastMaintanance = DateTime.Now;
      Console.WriteLine($"{Model} Perawatan selesai pada {LastMaintanance:yyy-MM-dd}");
    }

    public DateTime GetLastMaintenanceDate()
    {
      return LastMaintanance;
    }

    public bool NeedsMaintanance()
    {
      return Mileage > 5000 || DateTime.Now.Subtract(LastMaintanance).Days > 180;
    }
  }

  class AmphibiousVehicle : Vehicle, IDrivable, ISwimmable, IMaintanable
  {
    private double MaxLandSpeed;
    private double MaxWaterSpeed;
    private DateTime LastMaintenance;


    public AmphibiousVehicle(string model, int year, double landSpeed, double waterSpeed) : base(model, year)
    {
      this.MaxLandSpeed = landSpeed;
      this.MaxWaterSpeed = waterSpeed;
      this.LastMaintenance = DateTime.Now.AddMonths(-3);
    }

    public void StartEngine()
    {
      isRunning = true;
      Console.WriteLine($"{Model} On land/water operation");
    }

    public void StopEngine()
    {
      isRunning = false;
      Console.WriteLine($"{Model} Of");
    }

    public void Drive()
    {
      if (!isRunning)
      {
        Console.WriteLine($"{Model} cannot drive - engine not On");
      }
      Console.WriteLine($"{Model} is On on land at max {MaxLandSpeed}km/h");
    }

    public double GetMaxSpeed()
    {
      return MaxLandSpeed;
    }

    public void Swim()
    {
      if (!isRunning)
      {
        Console.WriteLine($"{Model} cannot SWIM - engine not On");
      }
      Console.WriteLine($"{Model} is On on SWIM at max {MaxLandSpeed} km/h");
    }

    public double GetSwimSpeed()
    {
      return MaxWaterSpeed;
    }

    public void Dive()
    {
      Console.WriteLine($"{Model} diving underwater");
    }

    public void PerforMaintenance()
    {
      LastMaintenance = DateTime.Now;
      Console.WriteLine($"{Model} Maintanance Complete (Land & Water Systems)");
    }

    public DateTime GetLastMaintenanceDate()
    {
      return LastMaintenance;
    }

    public bool NeedsMaintanance()
    {
      return DateTime.Now.Subtract(LastMaintenance).Days > 120;
    }
  }

  class VehicleManager
  {
    public static void CheckMaintanance(List<IMaintanable> vehicles)
    {
      Console.WriteLine("\n=== MAINTANANCE CHECK ===");
      foreach (IMaintanable vehicle in vehicles)
      {
        if (vehicle.NeedsMaintanance())
        {
          Console.WriteLine($"Vehicle needs Maintenance Last: {vehicle.GetLastMaintenanceDate():yyyy-MM-dd}");
          vehicle.PerforMaintenance();
        }
        else
        {
          Console.WriteLine($"Vehicle Maintanance up to date. Last. {vehicle.GetLastMaintenanceDate():yyyy-MM-dd}");
        }
      }
    }


    public static void TestFlightCapabilities(List<IFlyable> flyablesVehicles)
    {
      Console.WriteLine("\n=== FLIGHT TEST ===");
      foreach (IFlyable vehicle in flyablesVehicles)
      {
        Console.WriteLine($"Flight speed: {vehicle.GetFlightSpeed()} km/h");
        vehicle.Fly();
        vehicle.Land();
      }
    }
    public static void TestDrivingCapabilities(List<IDrivable> drivableVehicles)
    {
      Console.WriteLine("\n=== DRIVING TEST ===");
      foreach (IDrivable vehicle in drivableVehicles)
      {
        vehicle.StartEngine();
        Console.WriteLine($"Max speed: {vehicle.GetMaxSpeed()} km/h");
        vehicle.Drive();
        vehicle.StopEngine();
      }
    }
  }



}