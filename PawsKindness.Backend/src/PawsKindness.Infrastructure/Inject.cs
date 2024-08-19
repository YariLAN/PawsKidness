using Microsoft.Extensions.DependencyInjection;
using PawsKindness.Application.Volunteers.Interfaces;
using PawsKindness.Infrastructure.Repositories;

namespace PawsKindness.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IVolunteersRepository, VolunteersRepository>();

        return services;
    }
}
