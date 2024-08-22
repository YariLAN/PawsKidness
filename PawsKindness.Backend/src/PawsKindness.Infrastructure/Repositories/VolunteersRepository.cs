using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PawsKindness.Application.Services.Volunteers;
using PawsKindness.Domain.Models.PetControl;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Infrastructure.Repositories;

public class VolunteersRepository(ApplicationDbContext context) : IVolunteersRepository
{
    public async Task<Guid> CreateAsync(Volunteer volunteer, CancellationToken token = default)
    {
        await context.Volunteers.AddAsync(volunteer, token);
        
        await context.SaveChangesAsync();

        return volunteer.Id;
    }

    public async Task<Result<Volunteer, Error>> GetByPhoneAsync(string phone, CancellationToken token)
    {
        var volunteer = await context.Volunteers
            .Include(v => v.Pets)
            .ThenInclude(p => p.Photos)
            .FirstOrDefaultAsync(v => phone == v.PhoneNumber, token);

        if (volunteer is null)
            return Errors.PetControl.NotFound(phone);

        return volunteer;
    }
}
