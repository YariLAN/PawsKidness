using PawsKindness.Domain.Models.Volunteers;

namespace PawsKindness.Application.Services.Volunteers;

public interface IVolunteersRepository
{
    Task<Guid> CreateAsync(Volunteer volunteer, CancellationToken token = default);
}
