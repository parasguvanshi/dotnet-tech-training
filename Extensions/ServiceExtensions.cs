using SportsManagementApp.Services.EventRequestService.Implementations;
using SportsManagementApp.Services.Interfaces;

namespace SportsManagementApp.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEventRequestService, EventRequestService>();
        services.AddScoped<ISportService, SportService>();

    }
}

