using PawsKindness.Domain.Models.Species.Breeds;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.Species;

public class Species : Entity<SpeciesId>
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

    public static Species Create(SpeciesId id, string name)
    {
        return new Species(id, name);
    }
}
