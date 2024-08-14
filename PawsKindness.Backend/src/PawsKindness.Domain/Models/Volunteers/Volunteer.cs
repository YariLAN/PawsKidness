using PawsKindness.Domain.Models.Volunteers.Pets;

namespace PawsKindness.Domain.Models.Volunteers;

public class Volunteer
{
    private readonly List<Pet> _pets = [];

    public const string TABLE_NAME = "volunteers";

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

    public VolunteerDetails? Details { get; private set; }

    public IReadOnlyList<Pet> Pets => _pets;

    public void AddPet(Pet pet)
    {
        _pets.Add(pet);
    }
}
