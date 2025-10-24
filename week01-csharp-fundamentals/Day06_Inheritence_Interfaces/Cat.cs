using System;

namespace Inheritence_Interfaces
{
  public class Cat : Animal
  {
    public Cat(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
      Console.WriteLine($"{Name} the cat says: Meow!");
    }
  }
}
