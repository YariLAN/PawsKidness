using PawsKindness.Domain.Models.Volunteers.Pets;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.Volunteers;

public class Volunteer : Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];

    public FullName Name { get; private set; } = default!;

    public string Description { get; private set; } = string.Empty;

    public int YearsExperience { get; private set; }

    public int NumberPetsFoundAHome { get; private set; }

    public int NumberPetsLookingForAHome { get; private set; }

    public int NumberPersNeedHelp { get; private set; }

    public string PhoneNumber { get; private set; } = string.Empty;

    public VolunteerDetails? Details { get; private set; }

    public IReadOnlyList<Pet> Pets => _pets;

    private Volunteer(VolunteerId id) : base(id) { }

    private Volunteer(
        VolunteerId id, 
        FullName name, 
        string description, 
        int dateExperience,
        int numPetFound,
        int numPetLooking,
        int numPetHelp,
        string phone) : base(id)
    {
        Name = name;
        Description = description;
        YearsExperience = dateExperience;
        NumberPetsFoundAHome = numPetFound;
        NumberPetsLookingForAHome = numPetLooking;
        NumberPersNeedHelp = numPetHelp;
        PhoneNumber = phone;
    }

    public void AddPet(Pet pet)
    {
        _pets.Add(pet);
    }
}
