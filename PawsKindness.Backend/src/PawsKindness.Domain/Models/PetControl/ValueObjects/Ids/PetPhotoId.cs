namespace PawsKindness.Domain.Models.PetControl.ValueObjects.Ids;

public record PetPhotoId
{
    public Guid Value { get; }

    private PetPhotoId(Guid id)
    {
        Value = id;
    }

    public static PetPhotoId NewPetId() => new PetPhotoId(Guid.NewGuid());

    public static PetPhotoId Empty() => new PetPhotoId(Guid.Empty);

    public static PetPhotoId Create(Guid id) => new PetPhotoId(id);
}