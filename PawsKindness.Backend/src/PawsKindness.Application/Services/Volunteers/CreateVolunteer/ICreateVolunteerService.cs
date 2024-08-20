namespace PawsKindness.Application.Services.Volunteers.CreateVolunteer;

public interface ICreateVolunteerService
{
    public Task<Guid?> ExecuteAsync(CreateVolunteerRequest request, CancellationToken token);
}
