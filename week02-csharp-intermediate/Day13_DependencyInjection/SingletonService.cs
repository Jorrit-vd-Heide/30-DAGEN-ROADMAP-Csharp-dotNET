namespace day13_dependencyinjection;

public class SingletonService : ISingletonService
{
  public Guid Id { get; } = Guid.NewGuid();
}