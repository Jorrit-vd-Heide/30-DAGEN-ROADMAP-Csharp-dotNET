using System;

namespace Inheritence_Interfaces
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Animal / ISound demo");

      Animal dog = new Dog("Rex", 4);
      Animal cat = new Cat("Mittens", 2);

      ISound[] sounds = { dog, cat };

      foreach (var s in sounds)
      {
        Console.WriteLine(s.ToString());
        s.MakeSound();
      }
    }
  }
}
