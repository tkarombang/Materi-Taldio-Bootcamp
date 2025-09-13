using System;
namespace AccessModifier
{
  class Program
  {
    public class AccessModifierDemo
    {
      // public: dapat diakses dari mana saja
      public string PublicField = "Semua Orang Dapat Mengakses Ini";

      // Private: Hanya dapat diakses dalam class yang sama
      private string PrivateField = "Hanya Class ini yang dapat mengakses";

      // Protected: Dapat diakses Dalam Class dan Derived Classes
      protected string ProtectedField = "Class dan Derrived classes dapat mengakses";

      // Internal: Dapat diakses dalam assembly yang sama
      internal string InternalField = "Assembly yang sama dapat mengakses";

      // Protected Internal: Dapat diakses dalam assembly yang sama ATAU Derrived Classes
      protected internal string ProtectedInternalField = "Assembly atau derived classes";


      public void DemonstrateAccess()
      {
        Console.WriteLine(PublicField);
        Console.WriteLine(PrivateField);
        Console.WriteLine(ProtectedField);
        Console.WriteLine(InternalField);
        Console.WriteLine(ProtectedInternalField);
      }
    }

    class DerrivedClass : AccessModifierDemo
    {
      public void TestAccess()
      {
        // can access public, protected, internal, and protected internal
        Console.WriteLine(PublicField);                       // Ok
        Console.WriteLine(PrivateField);                      // Error - private
        Console.WriteLine(ProtectedField);                    // OK - protected
        Console.WriteLine(InternalField);                     // OK - (Same assembly)
        Console.WriteLine(ProtectedInternalField);            // OK - (Same assembly)
        
      }

    }
    class UnrelatedClass
    {
      public void TestAccess()
      {
        AccessModifierDemo demo = new AccessModifierDemo();
        
        // can access public and internal in same assembly
        Console.WriteLine(demo.PublicField);                       // Ok
        Console.WriteLine(demo.PrivateField);                      // Error - private
        Console.WriteLine(demo.ProtectedField);                    // Error - protected
        Console.WriteLine(demo.InternalField);                     // OK - (Same assembly)
        Console.WriteLine(demo.ProtectedInternalField);            // OK - (Same assembly)
        
      }

    }

  }


}