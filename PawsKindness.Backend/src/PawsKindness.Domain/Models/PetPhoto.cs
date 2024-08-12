namespace PawsKindness.Domain.Models
{
    public class PetPhoto
    {
        public Guid Id { get; set; }

        public string Path { get; set; } = string.Empty;

        public bool IsMain { get; set; }
    }
}
