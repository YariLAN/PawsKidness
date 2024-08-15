namespace PawsKindness.Domain.Models.Volunteers;

public record FullName
{
    public string Surname { get; }

    public string Name { get; }

    public string MiddleName { get; }

    public FullName(string surname, string name, string middleName)
    {
        Surname = surname;
        Name = name;
        MiddleName = middleName;
    }
}
