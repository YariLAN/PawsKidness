using PawsKindness.Application.Services.Volunteers;
using PawsKindness.Domain.Models.Volunteers;

namespace PawsKindness.Infrastructure.Repositories;

public class VolunteersRepository : IVolunteersRepository
{
    public Task<Guid> CreateAsync(Volunteer volunteer, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
