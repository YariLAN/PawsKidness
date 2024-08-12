namespace PawsKindness.Domain.Models;

public class Volunteer
{
    public Guid Id { get; set; }

    public string Surname { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string MiddleName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int YearsExperience { get; set; }

    public int NumberPetsFoundAHome { get; set; }

    public int NumberPetsLookingForAHome { get; set; }

    public int NumberPersNeedHelp { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public List<SocialNetwork> SocialNetworks { get; set; } = [];

    public List<Requisite> Requisites { get; set; } = [];

    public List<Pet> Pets { get; set; } = []; 
}

public class SocialNetwork
{
    public Guid Id { get; set; }

    public string Url { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}
