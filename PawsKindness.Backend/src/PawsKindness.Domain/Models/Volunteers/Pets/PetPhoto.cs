namespace PawsKindness.Domain.Models.Volunteers.Pets
{
    public class PetPhoto
    {
        public const string TABLE_NAME = "pet_photos";

        public Guid Id { get; private set; }

        public string Path { get; private set; } = string.Empty;

        public bool IsMain { get; private set; }
    }
}
