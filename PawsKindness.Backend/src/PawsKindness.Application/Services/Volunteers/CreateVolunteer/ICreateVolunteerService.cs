using CSharpFunctionalExtensions;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Application.Services.Volunteers.CreateVolunteer;

public interface ICreateVolunteerService
{
    public Task<Result<Guid, Error>> ExecuteAsync(CreateVolunteerRequest request, CancellationToken token);
}
