using CSharpFunctionalExtensions;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.PetControl.ValueObjects.Volunteers;

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

        if (surname.Length > Constants.LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalidLength(nameof(Surname)); 
        
        if (name.Length > Constants.LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalidLength(nameof(Name));  
        
        if (middleName.Length > Constants.LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalidLength(nameof(MiddleName));

        return new FullName(surname, name, middleName);
    }
}
