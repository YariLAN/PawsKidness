using PawsKindness.Domain.Models.SpeciesControl.Ids;

namespace PawsKindness.Domain.Models.PetControl.ValueObjects.Pets;

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
