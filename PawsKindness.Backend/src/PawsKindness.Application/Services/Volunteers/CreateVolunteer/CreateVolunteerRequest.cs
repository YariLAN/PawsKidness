using PawsKindness.Application.DtoModels;

namespace PawsKindness.Application.Services.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(
    string Surname,
    string Name,
    string MiddleName,
    string Description,
    int YearsExperience,
    string Phone,
    IEnumerable<RequisiteDto> RequisiteDtos,
    IEnumerable<SocialNetworkDto> SocialNetworkDtos);