namespace numberGuess
{
  class Program
  {
    static void Main(string[] args)
    {
      int randomNumber = new Random().Next(1, 100);
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

        if (userGuess < randomNumber)
        {
          Console.WriteLine("Te laag! Probeer het opnieuw.");
        }
        else if (userGuess > randomNumber)
        {
          Console.WriteLine("Te hoog! Probeer het opnieuw.");
        }
        else
        {
          Console.WriteLine("Gefeliciteerd! Je hebt het juiste getal geraden!");
        }
      }
    }
  }
}