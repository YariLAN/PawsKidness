using CSharpFunctionalExtensions;
using PawsKindness.Domain.Enums;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.Volunteers.Pets;

public class Pet : Shared.Entity<PetId>
{
    private readonly List<PetPhoto> _photos = [];

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public Type Type { get; private set; } = default!;

    public string Color { get; private set; } = string.Empty;

    public string HealthInfo { get; private set; } = string.Empty;

    public Address Address { get; private set; } = default!;

    public double Weight { get; private set; }

    public double Height { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; } = default!;

    public bool IsCastrated { get; private set; }

    public DateOnly? BirthDay { get; private set; }

    public bool IsVaccinated { get; private set; }

    public HelpStatus HelpStatus { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public PetDetails? Details { get; private set; }

    public IReadOnlyList<PetPhoto> Photos => _photos;

    private Pet(PetId id) : base(id) { }

    private Pet(
        PetId id,
        string name,
        string description,
        Type type,
        string color,
        string healthInfo,
        Address address,
        double weight,
        double height,
        PhoneNumber phoneNumber,
        bool isCastrated,
        DateOnly? birthDay,
        bool isVaccinated,
        HelpStatus helpStatus,
        DateTime createdAt,
        PetDetails? details = null) : base(id)
    {
        Name = name;
        Description = description;
        Type = type;
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

    public static Result<Pet, Error> Create(
        PetId id,
        string name,
        string description,
        Type type,
        string color,
        string healthInfo,
        Address address,
        double weight,
        double height,
        PhoneNumber phoneNumber,
        bool isCastrated,
        DateOnly? birthDay,
        bool isVaccinated,
        HelpStatus helpStatus,
        DateTime createdAt,
        PetDetails? details)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalid(nameof(Name));

        if (description.Length > Constants.HIGH_TEXT_LENGTH)
            return Errors.General.ValueIsInvalidLength(nameof(Description));

        if (color.Length > Constants.LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalidLength(nameof(Color));

        if (string.IsNullOrWhiteSpace(healthInfo) || healthInfo.Length > Constants.LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalid(nameof(HealthInfo));

        if (weight < 0.0 || height < 0.0)
            return Errors.General.ValueIsInvalid("Size");

        return new Pet(
            id,
            name,
            description,
            type,
            color,
            healthInfo,
            address,
            weight,
            height,
            phoneNumber,
            isCastrated,
            birthDay,
            isVaccinated,
            helpStatus,
            createdAt,
            details);
    }
}
