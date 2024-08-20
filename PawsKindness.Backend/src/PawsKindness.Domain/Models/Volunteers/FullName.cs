using CSharpFunctionalExtensions;
using PawsKindness.Domain.Shared;

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

    public static Result<FullName, Error> Create(string surname, string name, string middleName)
    {
        if (string.IsNullOrWhiteSpace(surname))
            return Errors.General.ValueIsEmpty(nameof(Surname));

        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsEmpty(nameof(Name));

        return new FullName(surname, name, middleName);
    }
}
