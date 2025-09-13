using System;
namespace Interface
{
  class Program
  {
    public static void Main(string[] args)
    {
      Airplane boeing = new Airplane("Boeing 737", 2020, 850);
      Car toyota = new Car("Toyota", 2023, 480);
      AmphibiousVehicle duck = new AmphibiousVehicle("DUKW", 2025, 80, 50);


      // LIST FOR DIFFERENT INTERFACE TYPES
      List<IFlyable> flyableList = new List<IFlyable> { boeing };
      List<ISwimmable> swimmablesList = new List<ISwimmable> { duck };
      List<IDrivable> drivablesList = new List<IDrivable> { toyota, duck };
      List<IMaintanable> maintanablesList = new List<IMaintanable> { boeing, toyota, duck };



      // TEST VEHICLE INFORMATION
      Console.WriteLine("=======vehivle=====");
      toyota.DisplayInfo();
      boeing.DisplayInfo();
      duck.DisplayInfo();


      // TEST INTERFACE CAPABILITIES
      VehicleManager.CheckMaintanance(maintanablesList);
      VehicleManager.TestFlightCapabilities(flyableList);
      VehicleManager.TestDrivingCapabilities(drivablesList);



      // TEST SWIMMING CAPABILITIES
      Console.WriteLine("======swimming test======");
      foreach (ISwimmable vehicle in swimmablesList)
      {
        if (vehicle is AmphibiousVehicle amphi)
        {
          amphi.StartEngine();
        }
        vehicle.Swim();
        vehicle.Dive();
      }






    }
  }
}