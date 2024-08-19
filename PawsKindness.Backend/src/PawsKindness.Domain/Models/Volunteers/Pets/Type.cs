using PawsKindness.Domain.Models.Species;

namespace PawsKindness.Domain.Models.Volunteers.Pets;

public record Type
{
    public SpeciesId SpeciesId { get; }

    public Guid BreedId { get; }

    private Type(SpeciesId speciesId, Guid breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }

    public static Type Create(SpeciesId speciesId, Guid breedId)
    {
        return new Type(speciesId, breedId);
    }
}
