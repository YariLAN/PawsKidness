using CSharpFunctionalExtensions;
using PawsKindness.Domain.Models.Species.Breeds;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.SpeciesControl.Entities;

public class Breed : Shared.Entity<BreedId>
{
    public string Name { get; private set; } = string.Empty;

    private Breed(BreedId id) : base(id) { }

    private Breed(BreedId id, string name) : base(id)
    {
        Name = name;
    }

    public static Result<Breed, Error> Create(BreedId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Errors.General.ValueIsEmpty(nameof(Name));
        }

        if (name.Length > Constants.LOW_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalidLength(nameof(Name));
        }

        return new Breed(id, name);
    }
}
