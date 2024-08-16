using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.Volunteers.Pets;

public class PetPhoto : Entity<PetPhotoId>
{
    public string Path { get; private set; } = string.Empty;

    public bool IsMain { get; private set; }
    
    private PetPhoto(PetPhotoId id) : base(id) { }

    private PetPhoto(PetPhotoId id, string path, bool isMain) : base(id)
    {
        Path = path;
        IsMain = isMain;
    } 

    public static PetPhoto Create(PetPhotoId id, string path, bool isMain)
    {
        return new PetPhoto(id, path, isMain);
    }
}