namespace PawsKindness.Domain.Models.SpeciesControl.Ids;

public record SpeciesId
{
    public Guid Value { get; }

    private SpeciesId(Guid id)
    {
        Value = id;
    }

    public static SpeciesId NewVolunteerId() => new SpeciesId(Guid.NewGuid());

    public static SpeciesId Empty() => new SpeciesId(Guid.Empty);

    public static SpeciesId Create(Guid id) => new SpeciesId(id);
}