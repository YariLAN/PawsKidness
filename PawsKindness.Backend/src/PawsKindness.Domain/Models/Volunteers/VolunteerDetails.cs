namespace PawsKindness.Domain.Models.Volunteers;

public record VolunteerDetails
{
    public List<Requisite> Requisites { get; } = [];

    public List<SocialNetwork> SocialNetworks { get; } = [];
}
