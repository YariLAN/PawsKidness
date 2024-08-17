namespace PawsKindness.Domain.Models.Species.Breeds;

public record BreedId
{
    public Guid Value { get; }

    protected BreedId(Guid id)
    {
        Value = id;
    }

    public static BreedId NewPetId() => new BreedId(Guid.NewGuid());

    public static BreedId Empty() => new BreedId(Guid.Empty);

    public static BreedId Create(Guid id) => new BreedId(id);
}