using PawsKindness.Application.DtoModels;

namespace PawsKindness.Application.Services.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(
    string surname,
    string name,
    string middleName,
    string description,
    string yearsExperience,
    string phone,
    List<RequisiteDto> requisiteDtos,
    List<SocialNetworkDto> socialNetworkDtos);