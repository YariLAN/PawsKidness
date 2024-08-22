namespace PawsKindness.Domain.Models.PetControl.ValueObjects.Pets;

public record PetDetails
{
    public IReadOnlyList<Requisite> Requisites { get; }

    public PetDetails() { }

    public PetDetails(IEnumerable<Requisite> requisites)
    {
        Requisites = requisites.ToList();
    }
}
