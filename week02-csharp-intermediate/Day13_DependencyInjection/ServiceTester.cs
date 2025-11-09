namespace day13_dependencyinjection;

public class ServiceTester
{
  private readonly ITransientService _transient;
  private readonly IScopedService _scoped;
  private readonly ISingletonService _singleton;

  public ServiceTester(
      ITransientService transient,
      IScopedService scoped,
      ISingletonService singleton)
  {
    _transient = transient;
    _scoped = scoped;
    _singleton = singleton;
  }

  public void Show()
  {
    Console.WriteLine($"Transient:  {_transient.Id}");
    Console.WriteLine($"Scoped:     {_scoped.Id}");
    Console.WriteLine($"Singleton:  {_singleton.Id}");
    Console.WriteLine();
  }
}