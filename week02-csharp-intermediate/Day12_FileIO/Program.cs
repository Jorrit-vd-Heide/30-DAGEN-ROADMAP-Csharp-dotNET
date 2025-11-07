using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace ConsoleApp
{
  // Model class representing a to-do item
  public class ToDoItem
  {
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public override string ToString()
    {
      string status = IsCompleted ? "[Voltooid]" : "[Openstaand]";
      return $"{Id}. Titel: {Title} - Status: {status} - Beschrijving: {Description}";
    }

    // File format: Id|Title|Description|IsCompleted
    public string ToFileString()
      => $"{Id}|{Title}|{Description}|{IsCompleted}";

    public static ToDoItem FromFileString(string line)
    {
      var parts = line.Split('|');
      return new ToDoItem
      {
        Id = int.Parse(parts[0]),
        Title = parts[1],
        Description = parts[2],
        IsCompleted = bool.Parse(parts[3])
      };
    }

  }

  // Service class to manage to-do items
  public class ToDoApp
  {
    string path = @"todo.txt";
    private List<ToDoItem> toDoList = new List<ToDoItem>();
    private int nextId = 1;

    public void Start()
    {
      LoadFromFile();

      while (true)
      {
        Console.Clear();
        Console.WriteLine("=== To-Do App ===");
        Console.WriteLine("1. Bekijk alle taken");
        Console.WriteLine("2. Voeg een taak toe");
        Console.WriteLine("3. Werk taak bij");
        Console.WriteLine("4. Verwijder een taak");
        Console.WriteLine("5. Zoek taken (LINQ)");
        Console.WriteLine("6. Toon statistieken (LINQ)");
        Console.WriteLine("7. Afsluiten");
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
            ShowStats();
            break;
          case "7":
            return;
          default:
            Console.WriteLine("Ongeldige optie. Druk op een toets om opnieuw te proberen.");
            break;
        }
      }
    }

    // Load task from file 
    private void LoadFromFile()
    {
      if (!File.Exists(path)) return;

      var lines = File.ReadAllLines(path);
      toDoList = lines.Select(ToDoItem.FromFileString).ToList();

      if (toDoList.Any())
        nextId = toDoList.Max(t => t.Id) + 1;
    }

    // Save task to file
    private void SaveToFile()
    {
      var lines = toDoList.Select(t => t.ToFileString());
      File.WriteAllLines(path, lines);
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

      var item = new ToDoItem
      {
        Id = nextId++,
        Title = title,
        Description = description,
        IsCompleted = false
      };
      toDoList.Add(item);
      SaveToFile();

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
        NextKey();
        return;
      }

      Console.WriteLine("Sorteeer op:");
      Console.WriteLine("1. ID");
      Console.WriteLine("2. Titel (A-Z)");
      Console.WriteLine("3. Titel (Z-A)");
      Console.WriteLine("4. Filteren op voltooid");
      Console.WriteLine("5. Filteren op openstaand");
      Console.Write("Kies een optie: ");

      string sortChoice = Console.ReadLine() ?? "";
      IEnumerable<ToDoItem> sorted = sortChoice switch
      {
        "1" => toDoList.OrderBy(t => t.Id),
        "2" => toDoList.OrderBy(t => t.Title),
        "3" => toDoList.OrderByDescending(t => t.Title),
        "4" => toDoList.Where(t => t.IsCompleted),
        "5" => toDoList.Where(t => !t.IsCompleted),

        _ => toDoList
      };

      foreach (var item in sorted)
      {
        Console.WriteLine(item.ToString());
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

          SaveToFile();
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
            SaveToFile();
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

      if (!results.Any())
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
      Console.WriteLine($"Totale taken: {total}");
      Console.WriteLine($"Voltooide taken: {completed}");
      Console.WriteLine($"Openstaande taken: {total - completed}");
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