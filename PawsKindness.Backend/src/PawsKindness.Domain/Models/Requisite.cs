namespace PawsKindness.Domain.Models;

public class Requisite
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;
}
