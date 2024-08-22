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
            return Errors.General.AlreadyExist();

        var name = FullName.Create(request.Surname, request.Name, request.MiddleName);

        if (name.IsFailure)
            return name.Error;

        var phone = PhoneNumber.Create(request.Phone);

        if (phone.IsFailure) 
            return phone.Error;

        var requisites = request.RequisiteDtos.ConvertAll(r => Requisite.Create(r.Name, r.Description));

        if (requisites.Any(r => r.IsFailure))
            return requisites.FirstOrDefault(x => x.IsFailure).Error;
        
        var socialNetworks = request.SocialNetworkDtos.ConvertAll(sn => SocialNetwork.Create(sn.Url, sn.Name));

        if (socialNetworks.Any(r => r.IsFailure))
            return socialNetworks.FirstOrDefault(x => x.IsFailure).Error;

        var volunteerDb = Volunteer.Create(
            VolunteerId.NewVolunteerId(),
            name.Value,
            request.Description,
            request.YearsExperience,
            phone.Value,
            VolunteerDetails.Create(requisites.Select(x => x.Value), socialNetworks.Select(x => x.Value)));

        if (volunteerDb.IsFailure)
            return volunteer.Error;

        return await _volunteersRepository.CreateAsync(volunteerDb.Value, token);
    }
}
