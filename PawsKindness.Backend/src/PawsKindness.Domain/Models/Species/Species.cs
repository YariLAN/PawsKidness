using CSharpFunctionalExtensions;
using PawsKindness.Domain.Models.Species.Breeds;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.Species;

public class Species : Shared.Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = [];

    public string Name { get; private set; } = string.Empty;

    private Species(SpeciesId id) : base(id) { }

    private Species(SpeciesId id, string name) : base(id)
    {
        Name = name;
    }

    public IReadOnlyList<Breed> Breeds => _breeds;

    public void AddBreed(Breed breed)
    {
        _breeds.Add(breed);
    }

    public static Result<Species, Error> Create(SpeciesId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Errors.General.ValueIsEmpty(nameof(Name));
        }

        if (name.Length > Constants.LOW_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalidLength(nameof(Name));
        }

        return new Species(id, name);
    }
}
