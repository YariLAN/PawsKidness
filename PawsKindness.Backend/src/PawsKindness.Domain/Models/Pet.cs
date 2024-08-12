using PawsKindness.Domain.Enums;

namespace PawsKindness.Domain.Models;

public class Pet
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Specie { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string BreedName { get; set; } = string.Empty;

    public string Color { get; set;} = string.Empty;

    public string HealthInfo { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public double Weight { get; set; }

    public double Height { get; set; } 

    public string PhoneNumber { get; set; } = string.Empty;

    public bool IsCastrated { get; set; }

    public DateTime BirthDay { get; set; }

    public bool IsVaccinated { get; set; }

    public HelpStatus HelpStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<Requisite> Requisites { get; set; } = [];

    public List<PetPhoto> Photos { get; set; } = [];
}