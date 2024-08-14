namespace PawsKindness.Domain.Models.Volunteers;

public record Requisite
{
    public Requisite(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }

    public string Description { get; }
}
