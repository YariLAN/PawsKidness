using CSharpFunctionalExtensions;
using PawsKindness.Domain.Models.PetControl;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Application.Services.Volunteers;

public interface IVolunteersRepository
{
    Task<Guid> CreateAsync(Volunteer volunteer, CancellationToken token = default);

    Task<Result<Volunteer, Error>> GetByPhoneAsync(string phone, CancellationToken token);
}
