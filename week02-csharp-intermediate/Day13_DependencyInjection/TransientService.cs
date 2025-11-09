namespace day13_dependencyinjection;

public class TransientService : ITransientService
{
  public Guid Id { get; } = Guid.NewGuid();
}