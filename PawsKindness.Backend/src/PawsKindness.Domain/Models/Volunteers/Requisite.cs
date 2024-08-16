namespace PawsKindness.Domain.Models.Volunteers;

public record Requisite
{
    public string Name { get; }

    public string Description { get; }

    private Requisite() { }

    private Requisite(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Requisite Create(string name, string description)
    {
        return new Requisite(name, description);
    }
}
