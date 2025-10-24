using System;

namespace Inheritence_Interfaces
{
  public abstract class Animal : ISound
  {
    public string Name { get; set; }
    public int Age { get; set; }

    protected Animal(string name, int age)
    {
      Name = name;
      Age = age;
    }

    public abstract void MakeSound();

    public override string ToString() => $"{GetType().Name} {Name} (age {Age})";
  }
}
