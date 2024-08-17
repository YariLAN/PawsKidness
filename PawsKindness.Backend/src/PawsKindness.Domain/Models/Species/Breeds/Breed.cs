using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.Species.Breeds;

public class Breed : Entity<BreedId>
{
    public string Name { get; private set; } = string.Empty;

    private Breed(BreedId id) : base(id) { }

    private Breed(BreedId id, string name) : base(id)
    {
        Name = name;
    }

    public static Breed Create(BreedId id, string name)
    {
        return new Breed(id, name);
    }
}
