using System;

namespace ClassesObjects
{

  public class Car
  {
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double Speed { get; set; }
    public bool IsEngineRunning { get; set; }

    public Car(string make, string model, int year, double speed, bool isEngineRunning)
    {
      Make = make;
      Model = model;
      Year = year;
      IsEngineRunning = isEngineRunning;
      // Enforce invariant: if engine isn't running, speed must be 0
      if (!IsEngineRunning && speed != 0)
      {
        Console.WriteLine("Engine is off, setting speed to 0.");
        Speed = 0;
      }
      else
      {
        Speed = speed;
      }
    }

    // Factory methods
    public static Car Create(string make, string model, int year, double speed, bool isEngineRunning)
    {
      return new Car(make, model, year, speed, isEngineRunning);
    }

    public static Car CreateDefault()
    {
      return new Car("Toyota", "Corolla", 2020, 0, false);
    }

    public static Car CreateFromConsole()
    {
      Console.Write("Make: ");
      var make = Console.ReadLine() ?? string.Empty;
      Console.Write("Model: ");
      var model = Console.ReadLine() ?? string.Empty;
      int year = ReadInt("Year: ");
      double speed = ReadDouble("Initial speed: ");
      bool isEngineRunning = ReadBool("Is engine running (y/n): ");
      if (!isEngineRunning && speed != 0)
      {
        Console.WriteLine("You specified the engine is off but provided a non-zero speed. Speed will be set to 0.");
        speed = 0;
      }
      return new Car(make, model, year, speed, isEngineRunning);

      static int ReadInt(string prompt)
      {
        while (true)
        {
          Console.Write(prompt);
          var s = Console.ReadLine();
          if (int.TryParse(s, out var v)) return v;
          Console.WriteLine("Invalid integer, try again.");
        }
      }

      static double ReadDouble(string prompt)
      {
        while (true)
        {
          Console.Write(prompt);
          var s = Console.ReadLine();
          if (double.TryParse(s, out var v)) return v;
          Console.WriteLine("Invalid number, try again.");
        }
      }

      static bool ReadBool(string prompt)
      {
        while (true)
        {
          Console.Write(prompt);
          var s = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();
          if (s == "y" || s == "yes") return true;
          if (s == "n" || s == "no") return false;
          Console.WriteLine("Please answer 'y' or 'n'.");
        }
      }
    }

    public void Accelerate(double amount)
    {
      if (!IsEngineRunning)
      {
        Console.WriteLine("Can't accelerate: the engine is off. Start the engine first.");
        return;
      }
      Speed += amount;
      Console.WriteLine($"The car is now going {Speed} mph.");
    }

    public void StartEngine()
    {
      IsEngineRunning = true;
      Console.WriteLine("The engine is starting.");
    }

    public void StopEngine()
    {
      IsEngineRunning = false;
      // When engine stops, the car must be still
      if (Speed != 0)
      {
        Speed = 0;
      }
      Console.WriteLine("The engine is stopping. Speed set to 0.");
    }

    public void Honk()
    {
      Console.WriteLine("Beep beep!");
    }
  }
  class Program
  {
    // Entry point
    public static void Main(string[] args)
    {
      // Create using factory
      var car1 = Car.Create("Toyota", "Corolla", 2020, 0, false);
      Console.WriteLine($"Car Make: {car1.Make}, Model: {car1.Model}, Year: {car1.Year}, Speed: {car1.Speed}, Engine Running: {car1.IsEngineRunning}");

      // Demonstrate methods on the Car instance
      car1.StartEngine();
      car1.Accelerate(15);
      car1.Honk();
      car1.StopEngine();

      // Interactive creation via console
      Console.WriteLine();
      Console.WriteLine("Create a car interactively (press Enter to start or Ctrl+C to skip)...");
      Console.ReadLine();
      var interactive = Car.CreateFromConsole();
      Console.WriteLine($"Created: {interactive.Make} {interactive.Model} ({interactive.Year}) speed={interactive.Speed}, engineRunning={interactive.IsEngineRunning}");
      interactive.StartEngine();
      interactive.Accelerate(10);
      interactive.Honk();
      interactive.StopEngine();
    }
  }
}