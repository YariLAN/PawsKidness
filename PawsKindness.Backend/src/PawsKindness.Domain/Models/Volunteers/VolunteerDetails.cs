namespace PawsKindness.Domain.Models.Volunteers;

public record VolunteerDetails
{
    public IReadOnlyList<Requisite> Requisites { get; }

    public IReadOnlyList<SocialNetwork> SocialNetworks { get; }

    public VolunteerDetails() { }

    public VolunteerDetails(
        IEnumerable<Requisite> requisites,
        IEnumerable<SocialNetwork> socialNetworks)
    {
        Requisites = requisites.ToList();
        SocialNetworks = socialNetworks.ToList();
    }
}
