namespace PawsKindness.Domain.Models.Volunteers.Pets;

public record PetDetails
{
    public List<Requisite> Requisites { get; } = [];
}
