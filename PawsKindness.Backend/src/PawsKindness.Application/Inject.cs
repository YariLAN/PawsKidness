using Microsoft.Extensions.DependencyInjection;
using PawsKindness.Application.Volunteers.CreateVolunteer;

namespace PawsKindness.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateVolunteerService>();

        return services;
    }
}
