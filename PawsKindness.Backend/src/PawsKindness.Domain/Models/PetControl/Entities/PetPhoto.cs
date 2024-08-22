using CSharpFunctionalExtensions;
using PawsKindness.Domain.Models.PetControl.ValueObjects.Ids;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.PetControl.Entities;

public class PetPhoto : Shared.Entity<PetPhotoId>
{
    public string Path { get; private set; } = string.Empty;

    public bool IsMain { get; private set; }

    private PetPhoto(PetPhotoId id) : base(id) { }

    private PetPhoto(PetPhotoId id, string path, bool isMain) : base(id)
    {
        Path = path;
        IsMain = isMain;
    }

    public static Result<PetPhoto, Error> Create(PetPhotoId id, string path, bool isMain)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return Errors.General.ValueIsEmpty(nameof(Path));
        }

        return new PetPhoto(id, path, isMain);
    }
}