namespace PawsKindness.Domain.Models.Volunteers;

public record FullName
{
    public string Surname { get; }

    public string Name { get; }

    public string MiddleName { get; }

    private FullName(string surname, string name, string middleName)
    {
        Surname = surname;
        Name = name;
        MiddleName = middleName;
    }

    public static FullName Create(string surname, string name, string middleName)
    {
        return new FullName(surname, name, middleName);
    }
}
