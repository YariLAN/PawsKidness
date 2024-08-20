using CSharpFunctionalExtensions;
using PawsKindness.Domain.Shared;

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

    public static Result<Requisite, Error> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            return Errors.General.ValueIsEmpty(nameof(Name));

        if (description.Length > Constants.HIGH_TEXT_LENGTH)
            return Errors.General.ValueIsInvalidLength(nameof(Description));

        return new Requisite(name, description);
    }
}
