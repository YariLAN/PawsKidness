using PawsKindness.Domain.Enums;

namespace PawsKindness.Domain.Models;

public class Pet
{
    private readonly List<Requisite> _requisites = [];

    private readonly List<PetPhoto> _photos = [];

    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Species { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public string BreedName { get; private set; } = string.Empty;

    public string Color { get; private set;} = string.Empty;

    public string HealthInfo { get; private set; } = string.Empty;

    public string Address { get; private set; } = string.Empty;

    public double Weight { get; private set; }

    public double Height { get; private set; } 

    public string PhoneNumber { get; private set; } = string.Empty;

    public bool IsCastrated { get; private set; }

    public DateTime BirthDay { get; private set; }

    public bool IsVaccinated { get; private set; }

    public HelpStatus HelpStatus { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public IReadOnlyList<Requisite> Requisites => _requisites;

    public IReadOnlyList<PetPhoto> Photos => _photos;

    public void AddRequisite(Requisite requisite)
    {
        _requisites.Add(requisite);
    }

    public void AddPhoto(PetPhoto photo)
    {
        _photos.Add(photo);
    }
}
