using PawsKindness.Domain.Models.Species;
using PawsKindness.Domain.Models.Species.Breeds;

namespace PawsKindness.Domain.Models.Volunteers.Pets;

public record Type
{
    public SpeciesId SpeciesId { get; }

    public BreedId BreedId { get; }

    private Type(SpeciesId speciesId, BreedId breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }

    public static Type Create(SpeciesId speciesId, BreedId breedId)
    {
        return new Type(speciesId, breedId);
    }
}
