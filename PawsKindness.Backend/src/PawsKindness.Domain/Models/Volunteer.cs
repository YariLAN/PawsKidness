namespace PawsKindness.Domain.Models;

public class Volunteer
{
    private readonly List<SocialNetwork> _socialNetworks = [];

    private readonly List<Requisite> _requisites = [];

    private readonly List<Pet> _pets = [];

    public Guid Id { get; private set; }

    public string Surname { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public string MiddleName { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public int YearsExperience { get; private set; }

    public int NumberPetsFoundAHome { get; private set; }

    public int NumberPetsLookingForAHome { get; private set; }

    public int NumberPersNeedHelp { get; private set; }

    public string PhoneNumber { get; private set; } = string.Empty;

    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

    public IReadOnlyList<Requisite> Requisites => _requisites;

    public IReadOnlyList<Pet> Pets => _pets; 

    public void AddSocialNetWork(SocialNetwork socialNetwork)
    {
        _socialNetworks.Add(socialNetwork);
    }

    public void AddRequisite(Requisite requisite)
    {
        _requisites.Add(requisite);
    }

    public void AddPet(Pet pet)
    {
        _pets.Add(pet);
    }
}
