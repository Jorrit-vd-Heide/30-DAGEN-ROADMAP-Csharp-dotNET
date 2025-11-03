using System;
using System.Runtime.InteropServices;

namespace ConsoleApp
{
  // Model class representing a to-do item
  public class ToDoItem
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public override string ToString()
    {
      string status = IsCompleted ? "[Voltooid]" : "[Openstaand]";
      return $"{Id}. Titel: {Title} - Status: {status} - Beschrijving: {Description}";
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
        Console.WriteLine("6. Toon alleen voltooid of openstaande taken (LINQ)");
        Console.WriteLine("7. Toon statistieken (LINQ)");
        Console.WriteLine("8. Afsluiten");
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
            DeleteTask();
            break;
          case "5":
            SearchTask();
            break;
          case "6":
            FilterTasks();
            break;
          case "7":
            ShowStats();
            break;
          case "8":
            return;
          default:
            Console.WriteLine("Ongeldige optie. Druk op een toets om opnieuw te proberen.");
            break;
        }
      }
    }

    // Add Tasks method
    private void AddTask()
    {
      Console.Clear();
      Console.WriteLine("=== Voeg een taak toe ===");
      Console.Write("Titel: ");
      string title = Console.ReadLine() ?? "";
      Console.Write("Beschrijving: ");
      string description = Console.ReadLine() ?? "";

      try
      {
        if (string.IsNullOrWhiteSpace(title))
        {
          throw new ArgumentException("De titel mag niet leeg zijn.");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Fout bij het toevoegen van de taak: {ex.Message}");
        NextKey();
        return;
      }

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

      if (!toDoList.Any())
      {
        Console.WriteLine("Geen taken gevonden.");
      }

      Console.WriteLine("Sorteeer op:");
      Console.WriteLine("1. ID");
      Console.WriteLine("2. Titel (A-Z)");
      Console.WriteLine("3. Titel (Z-A)");
      Console.Write("Kies een optie: ");

      string sortChoice = Console.ReadLine() ?? "";
      IEnumerable<ToDoItem> sortedList = toDoList;

      sortedList = sortChoice switch
      {
        "1" => toDoList.OrderBy(t => t.Id),
        "2" => toDoList.OrderBy(t => t.Title),
        "3" => toDoList.OrderByDescending(t => t.Title),
        _ => sortedList
      };

      foreach (var item in sortedList)
      {
        Console.WriteLine(item.ToString());
      }

      NextKey();
    }

    // Filter Tasks using LINQ
    private void FilterTasks()
    {
      Console.Clear();
      Console.WriteLine("=== Filter taken ===");
      Console.WriteLine("1. Alleen voltooid");
      Console.WriteLine("2. Alleen openstaand");
      Console.Write("Kies een optie: ");

      String choice = Console.ReadLine() ?? "";

      var filteredList = choice switch
      {
        "1" => toDoList.Where(t => t.IsCompleted),
        "2" => toDoList.Where(t => !t.IsCompleted),
        _ => Enumerable.Empty<ToDoItem>()
      };

      if (!filteredList.Any())
      {
        Console.WriteLine("Ongeldige optie.");
      }
      else
      {
        foreach (var item in filteredList)
        {
          Console.WriteLine(item.ToString());
        }
        NextKey();
      }
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

    // Delete Tasks
    private void DeleteTask()
    {
      Console.Clear();
      Console.WriteLine("=== Verwijder een taak ===");
      Console.Write("Voer het ID van de taak in die je wilt verwijderen: ");
      if (int.TryParse(Console.ReadLine(), out int id))
      {
        var item = toDoList.FirstOrDefault(t => t.Id == id);
        if (item != null)
        {
          Console.Write("Weet je zeker dat je deze taak wilt verwijderen? (y/n): ");
          string confirm = Console.ReadLine() ?? "";
          if (confirm.ToLower() == "y")
          {
            toDoList.Remove(item);
            Console.WriteLine("Taak verwijderd!");
          }
          else
          {
            Console.WriteLine("Verwijdering geannuleerd.");
          }
        }
      }
      else
      {
        Console.WriteLine("Ongeldig ID.");
      }
      NextKey();
    }

    // Search Tasks using LINQ
    private void SearchTask()
    {
      Console.Clear();
      Console.WriteLine("=== Zoek taken ===");
      Console.Write("Voer zoekterm in: ");
      string searchTerm = Console.ReadLine() ?? "";

      var results = toDoList
        .Where(t => (t.Title != null && t.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (t.Description != null && t.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
        .ToList();

      if (results.Count == 0)
      {
        Console.WriteLine("Geen taken gevonden die overeenkomen met de zoekterm.");
      }
      else
      {
        Console.WriteLine("Gevonden taken:");
        foreach (var item in results)
        {
          Console.WriteLine(item.ToString());
        }
      }
      NextKey();
    }

    // Show Statistics using LINQ
    private void ShowStats()
    {
      Console.Clear();
      Console.WriteLine("=== Statistieken ===");

      int total = toDoList.Count;
      int completed = toDoList.Count(t => t.IsCompleted);
      int pending = total - completed;

      Console.WriteLine($"Totale taken: {total}");
      Console.WriteLine($"Voltooide taken: {completed}");
      Console.WriteLine($"Openstaande taken: {pending}");
      NextKey();
    }


    // Helper method to wait for a key press
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