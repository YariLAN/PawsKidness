namespace PawsKindness.Domain.Models.PetControl.ValueObjects.Ids;

public record VolunteerId
{
    public Guid Value { get; }

    private VolunteerId(Guid id)
    {
        Value = id;
    }

    public static VolunteerId NewVolunteerId() => new VolunteerId(Guid.NewGuid());

    public static VolunteerId Empty() => new VolunteerId(Guid.Empty);

    public static VolunteerId Create(Guid id) => new VolunteerId(id);

    public static implicit operator VolunteerId(Guid id) => new(id);

    public static implicit operator Guid(VolunteerId id)
    {
        ArgumentNullException.ThrowIfNull(id);

        return id.Value;
    }
}
