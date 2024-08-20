using CSharpFunctionalExtensions;
using PawsKindness.Domain.Enums;
using PawsKindness.Domain.Models.Volunteers.Pets;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.Volunteers;

public class Volunteer : Shared.Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];

    public FullName Name { get; private set; } = default!;

    public string Description { get; private set; } = string.Empty;

    public int YearsExperience { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; } = default!;

    public VolunteerDetails? Details { get; private set; }

    public IReadOnlyList<Pet> Pets => _pets;

    private Volunteer(VolunteerId id) : base(id) { }

    private Volunteer(
        VolunteerId id, 
        FullName name, 
        string description, 
        int dateExperience, 
        PhoneNumber phone, 
        VolunteerDetails? details = null)
        : base(id)
    {
        Name = name;
        Description = description;
        YearsExperience = dateExperience;
        PhoneNumber = phone;
        Details = details;
    }

    public int CountPetsFoundAHome => _pets.Count(x => x.HelpStatus == HelpStatus.FoundAHome);

    public int CountPetsLookingForAHome => _pets.Count(x => x.HelpStatus == HelpStatus.LookingForAHome);

    public int CountPersNeedHelp => _pets.Count(x => x.HelpStatus == HelpStatus.NeedHelp);

    public void AddPet(Pet pet)
    {
        _pets.Add(pet);
    }

    public static Result<Volunteer, Error> Create(
        VolunteerId id, 
        FullName name, 
        string description, 
        int yearExperience, 
        PhoneNumber phone,
        VolunteerDetails? details)
    {
        if (description.Length > Constants.HIGH_TEXT_LENGTH)
            return Errors.General.ValueIsInvalidLength(nameof(Description));

        if (yearExperience < 0 || yearExperience > 100)
            return Errors.General.ValueIsInvalid(nameof(YearsExperience));

        return new Volunteer(id, name, description, yearExperience, phone, details);
    }
}
