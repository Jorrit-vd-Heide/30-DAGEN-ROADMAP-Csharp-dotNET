namespace numberGuess
{
  class Program
  {
    static void Main(string[] args)
    {
      int randomNumber = new Random().Next(1, 101); // willekeurig getal tussen 1 en 100
      int userGuess = 0;
      Console.WriteLine("Welkom bij het Getallen Raadspel!");
      while (userGuess != randomNumber)
      {
        Console.Write("Raad een getal tussen 1 en 100: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out userGuess))
        {
          Console.WriteLine("Ongeldige invoer. Probeer het opnieuw.");
          continue;
        }

        // Lokale functie voor vergelijking
        void Comparison(int randomNumber, int userGuess)
        {
          switch (userGuess)
          {
            case var n when n < randomNumber:
              Console.WriteLine("Te laag! Probeer het opnieuw.");
              break;
            case var n when n > randomNumber:
              Console.WriteLine("Te hoog! Probeer het opnieuw.");
              break;
            default:
              Console.WriteLine("Gefeliciteerd! Je hebt het juiste getal geraden!");
              break;
          }
        }
        Comparison(randomNumber, userGuess);
      }
    }
  }
}