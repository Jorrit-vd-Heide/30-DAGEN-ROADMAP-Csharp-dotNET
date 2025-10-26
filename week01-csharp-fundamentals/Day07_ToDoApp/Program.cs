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
      string status = IsCompleted ? "[Voltooid]" : "[Openstaand]";
      return $"{Id}. {Title} - {status}";
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
            ViewTasks();
            break;
          case "2":
            AddTask();
            break;
          case "3":
            UpdateTask();
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

      Console.WriteLine("Taak toegevoegd!");
      NextKey();
    }

    // Read Tasks
    private void ViewTasks()
    {
      Console.Clear();
      Console.WriteLine("=== Alle taken ===");
      if (toDoList.Count == 0)
      {
        Console.WriteLine("Geen taken gevonden.");
      }
      else
      {
        Console.WriteLine("=== Taken ===");
        foreach (var item in toDoList)
        {
          Console.WriteLine(item.ToString());
        }
      }
      NextKey();
    }

    // Update Tasks
    private void UpdateTask()
    {
      Console.Clear();
      Console.WriteLine("=== Werk een taak bij ===");
      Console.Write("Voer het ID van de taak in die je wilt bijwerken: ");
      if (int.TryParse(Console.ReadLine(), out int id))
      {
        var item = toDoList.FirstOrDefault(t => t.Id == id);
        if (item != null)
        {
          Console.Write("Nieuwe titel (laat leeg om ongewijzigd te laten): ");
          string title = Console.ReadLine() ?? "";
          if (!string.IsNullOrWhiteSpace(title))
          {
            item.Title = title;
          }

          Console.Write("Nieuwe beschrijving (laat leeg om ongewijzigd te laten): ");
          string description = Console.ReadLine() ?? "";
          if (!string.IsNullOrWhiteSpace(description))
          {
            item.Description = description;
          }

          Console.Write("Is de taak voltooid? (y/n): ");
          string isCompletedInput = Console.ReadLine() ?? "";
          if (isCompletedInput.ToLower() == "y")
          {
            item.IsCompleted = true;
          }
          else if (isCompletedInput.ToLower() == "n")
          {
            item.IsCompleted = false;
          }

          Console.WriteLine("Taak bijgewerkt!");
        }
        else
        {
          Console.WriteLine("Taak niet gevonden.");
        }
      }
      else
      {
        Console.WriteLine("Ongeldig ID.");
      }
      NextKey();
    }

    private static void NextKey()
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