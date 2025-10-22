// See https://aka.ms/new-console-template for more information
namespace RekenMachine
{
  class Program
  {
    public static void Main(string[] args)
    {
      double eersteGetal = 0;
      double tweedeGetal = 0;
      Console.WriteLine("Dit is een rekenmachine!!!");

      // Eerste getal
      Console.WriteLine("Vul een getal in:");
      string? input = Console.ReadLine();
      while (string.IsNullOrWhiteSpace(input) || !double.TryParse(input, out eersteGetal))
      {
        Console.WriteLine("Ongeldige invoer. Voer een geheel getal in:");
        input = Console.ReadLine();
      }

      // Tweede getal
      Console.WriteLine("Vul een tweede getal in:");
      string? input2 = Console.ReadLine();
      while (string.IsNullOrWhiteSpace(input2) || !double.TryParse(input2, out tweedeGetal))
      {
        Console.WriteLine("Ongeldige invoer. Voer een geheel getal in:");
        input2 = Console.ReadLine();
      }

      // Kies bewerking
      Console.WriteLine("Kies een bewerking: + voor optellen, - voor aftrekken, * voor vermenigvuldigen, / voor delen");
      string? operation = Console.ReadLine();
      while (string.IsNullOrWhiteSpace(operation) || !(operation == "+" || operation == "-" || operation == "*" || operation == "/"))
      {
        Console.WriteLine("Ongeldige bewerking. Gebruik één van: + - * /");
        operation = Console.ReadLine();
      }

      // Bereken resultaat met foutafhandeling
      try
      {
        double resultaat = operation switch
        {
          "+" => Calculator.Add(eersteGetal, tweedeGetal),
          "-" => Calculator.Subtract(eersteGetal, tweedeGetal),
          "*" => Calculator.Multiply(eersteGetal, tweedeGetal),
          "/" => tweedeGetal == 0 ? throw new DivideByZeroException() : Calculator.Divide(eersteGetal, tweedeGetal),
          _ => throw new InvalidOperationException("Onbekende bewerking")
        };

        Console.WriteLine($"Resultaat: {resultaat}");
      }
      catch (DivideByZeroException)
      {
        Console.WriteLine("Fout: delen door nul is niet toegestaan.");
      }
    }
  }
}