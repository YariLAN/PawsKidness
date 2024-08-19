using PawsKindness.Domain.Models.Volunteers;

namespace PawsKindness.Application.Volunteers.Interfaces;

public interface IVolunteersRepository
{
    Task<Guid> CreateAsync(Volunteer volunteer, CancellationToken token = default);
}
