namespace PawsKindness.Application.Volunteers.CreateVolunteer;

public interface ICreateVolunteerService
{
    public Task<Guid?> ExecuteAsync(CreateVolunteerRequest request, CancellationToken token);
}
