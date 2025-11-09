namespace day13_dependencyinjection;

public class ScopedService : IScopedService
{
  public Guid Id { get; } = Guid.NewGuid();
}