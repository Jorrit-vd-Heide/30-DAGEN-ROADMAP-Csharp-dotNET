using System.Runtime.InteropServices;

namespace Day08_CollectionsGenerics
{
  internal class Program
  {
    public void FruitList()
    {
      List<string> fruits = ["Apple", "Banana", "Orange"];
      foreach (var fruit in fruits)
      {
        Console.WriteLine($"This is a {fruit}!");
      }
    }

    public void ModifyFruitList()
    {
      List<string> fruits = ["Apple", "Banana", "Orange"];
      fruits.Add("Grapes");
      fruits.Add("Mango");
      fruits.Remove("Banana");
      foreach (var fruit in fruits)
      {
        Console.WriteLine($"I am a {fruits[0]}.");
        Console.WriteLine($"I've added {fruits[2]} and {fruits[3]} to the list.");
        Console.WriteLine($"The list has {fruits.Count} fruits in it");
      }
    }

    public void FibonacciGenerics()
    {
      List<int> fibonacciNumbers = [1, 1];

      while (fibonacciNumbers.Count < 20)
      {
        var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
        var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

        fibonacciNumbers.Add(previous + previous2);
      }
      foreach (var item in fibonacciNumbers)
      {
        Console.WriteLine(item);
      }
    }
    
    static void Main(string[] args)
    {
      Program program = new Program();
      program.FibonacciGenerics();
    }
  }
}
