using CSharpFunctionalExtensions;
using PawsKindness.Domain.Models.PetControl;
using PawsKindness.Domain.Models.PetControl.ValueObjects;
using PawsKindness.Domain.Models.PetControl.ValueObjects.Ids;
using PawsKindness.Domain.Models.PetControl.ValueObjects.Volunteers;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Application.Services.Volunteers.CreateVolunteer;

public class CreateVolunteerService : ICreateVolunteerService
{
    private readonly IVolunteersRepository _volunteersRepository;

    public CreateVolunteerService(IVolunteersRepository volunteersRepository)
    {
        _volunteersRepository = volunteersRepository;
    }

    public async Task<Result<Guid, Error>> ExecuteAsync(CreateVolunteerRequest request, CancellationToken token = default)
    {
        var volunteer = await _volunteersRepository.GetByPhoneAsync(request.Phone, token);

        if (volunteer.IsSuccess)
            return Errors.General.AlreadyExist(nameof(volunteer));

        var name = FullName.Create(request.Surname, request.Name, request.MiddleName).Value;

        var phone = PhoneNumber.Create(request.Phone).Value;

        var requisites = request.RequisiteDtos.Select(r => Requisite.Create(r.Name, r.Description)).Select(x => x.Value);
        
        var socialNetworks = request.SocialNetworkDtos.Select(sn => SocialNetwork.Create(sn.Url, sn.Name)).Select(x => x.Value);

        var volunteerDb = Volunteer.Create(
            VolunteerId.NewVolunteerId(),
            name,
            request.Description,
            request.YearsExperience,
            phone,
            VolunteerDetails.Create(requisites, socialNetworks));

        if (volunteerDb.IsFailure)
            return volunteer.Error;

        return await _volunteersRepository.CreateAsync(volunteerDb.Value, token);
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               