using PawsKindness.Domain.Models.PetControl.ValueObjects;

namespace PawsKindness.Domain.Models.PetControl.ValueObjects.Volunteers;

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

    public static VolunteerDetails Create(
        IEnumerable<Requisite> requisites,
        IEnumerable<SocialNetwork> socialNetworks)
    {
        return new VolunteerDetails(requisites, socialNetworks);
    }
}
