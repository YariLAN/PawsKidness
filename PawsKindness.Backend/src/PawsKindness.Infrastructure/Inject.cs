using Microsoft.Extensions.DependencyInjection;
using PawsKindness.Application.Services.Volunteers;
using PawsKindness.Infrastructure.Repositories;

namespace PawsKindness.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ApplicationDbContext>();

        services.AddScoped<IVolunteersRepository, VolunteersRepository>();

        return services;
    }
}
