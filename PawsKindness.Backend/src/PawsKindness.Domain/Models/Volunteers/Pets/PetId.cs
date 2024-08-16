namespace PawsKindness.Domain.Models.Volunteers.Pets;

public record PetId
{
    public Guid Value { get; }

    protected PetId(Guid id) 
    {
        Value = id;
    }

    public static PetId NewPetId() => new PetId(Guid.NewGuid());

    public static PetId Empty() => new PetId(Guid.Empty);

    public static PetId Create(Guid id) => new PetId(id);
}