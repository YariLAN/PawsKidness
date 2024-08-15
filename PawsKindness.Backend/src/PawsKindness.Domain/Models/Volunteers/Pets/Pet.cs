using PawsKindness.Domain.Enums;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.Volunteers.Pets;

public class Pet : Entity<PetId>
{
    private readonly List<PetPhoto> _photos = [];

    public string Name { get; private set; } = string.Empty;

    public string Species { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public string BreedName { get; private set; } = string.Empty;

    public string Color { get; private set; } = string.Empty;

    public string HealthInfo { get; private set; } = string.Empty;

    public Address Address { get; private set; } = default!;

    public double Weight { get; private set; }

    public double Height { get; private set; }

    public string PhoneNumber { get; private set; } = string.Empty;

    public bool IsCastrated { get; private set; }

    public DateTime BirthDay { get; private set; }

    public bool IsVaccinated { get; private set; }

    public HelpStatus HelpStatus { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public PetDetails? Details { get; private set; }

    public IReadOnlyList<PetPhoto> Photos => _photos;

    private Pet(PetId id) : base(id) { }

    private Pet(
        PetId id,
        string name,
        string species,
        string description,
        string breedName,
        string color,
        string healthInfo,
        Address address,
        double weight,
        double height,
        string phoneNumber,
        bool isCastrated,
        DateTime birthDay,
        bool isVaccinated,
        HelpStatus helpStatus,
        DateTime createdAt,
        PetDetails? details) : base(id)
    {
        Name = name;
        Species = species;
        Description = description;
        BreedName = breedName;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Weight = weight;
        Height = height;
        PhoneNumber = phoneNumber;
        IsCastrated = isCastrated;
        BirthDay = birthDay;
        IsVaccinated = isVaccinated;
        HelpStatus = helpStatus;
        CreatedAt = createdAt;
        Details = details;
    }

    public void AddPhoto(PetPhoto photo)
    {
        _photos.Add(photo);
    }
}
