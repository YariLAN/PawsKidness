using PawsKindness.Application.Services.Volunteers;

namespace PawsKindness.Application.Services.Volunteers.CreateVolunteer;

public class CreateVolunteerService : ICreateVolunteerService
{
    private readonly IVolunteersRepository _volunteersRepository;

    public CreateVolunteerService(IVolunteersRepository volunteersRepository)
    {
        _volunteersRepository = volunteersRepository;
    }

    public async Task<Guid?> ExecuteAsync(CreateVolunteerRequest request, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
