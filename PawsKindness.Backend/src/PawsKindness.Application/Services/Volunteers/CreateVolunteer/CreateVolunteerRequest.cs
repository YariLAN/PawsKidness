using PawsKindness.Application.DtoModels;

namespace PawsKindness.Application.Services.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(
    FullNameDto FullName,
    string Description,
    int YearsExperience,
    string Phone,
    IEnumerable<RequisiteDto> RequisiteDtos,
    IEnumerable<SocialNetworkDto> SocialNetworkDtos);