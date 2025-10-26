using System;

namespace ConsoleApp
{
  // Model class representing a to-do item
  public class ToDoItem
  {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public override string ToString()
    {
      return $"{Id}. {Title} - {(IsCompleted ? "✔ Voltooid" : "❌ Openstaand")}";
    }
  }

  // Service class to manage to-do items
  public class ToDoApp
  {
    private List<ToDoItem> toDoList = new List<ToDoItem>();
    private int nextId = 1;

    public void Start()
    {
      while (true)
      {
        Console.Clear();
        Console.WriteLine("=== To-Do App ===");
        Console.WriteLine("1. Bekijk alle taken");
        Console.WriteLine("2. Voeg een taak toe");
        Console.WriteLine("3. Werk taak bij");
        Console.WriteLine("4. Verwijder een taak");
        Console.WriteLine("5. Zoek taken (LINQ)");
        Console.WriteLine("6. Afsluiten");
        Console.Write("Kies een optie: ");

        String choice = Console.ReadLine() ?? "";
        switch (choice)
        {
          case "1":
            //ViewTasks();
            break;
          case "2":
            AddTask();
            break;
          case "3":
            //UpdateTask();
            break;
          case "4":
            //DeleteTask();
            break;
          case "5":
            //SearchTasks();
            break;
          case "6":
            return;
          default:
            Console.WriteLine("Ongeldige optie. Druk op een toets om opnieuw te proberen.");
            break;
        }
      }
    }

    // Add Task method
    private void AddTask()
    {
      Console.Clear();
      Console.WriteLine("=== Voeg een taak toe ===");
      Console.Write("Titel: ");
      string title = Console.ReadLine() ?? "";
      Console.Write("Beschrijving: ");
      string description = Console.ReadLine() ?? "";

      toDoList.Add(new ToDoItem
      {
        Id = nextId++,
        Title = title,
        Description = description,
        IsCompleted = false
      });

      Console.WriteLine("Taak toegevoegd! Druk op een toets om terug te keren naar het menu.");
      ReadEnterKey();
    }

    private void ReadEnterKey()
    {
      Console.WriteLine("\nDruk op een toets om verder te gaan...");
      Console.ReadKey();
    }

    // PROGRAM ENTRY POINT
    class Program
    {
      static void Main()
      {
        ToDoApp app = new ToDoApp();
        app.Start();
      }
    }
  }
}