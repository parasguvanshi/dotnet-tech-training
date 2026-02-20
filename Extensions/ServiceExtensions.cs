using Microsoft.Extensions.DependencyInjection;
using SportsManagementApp.Services;
using SportsManagementApp.Services.EventRequestService;


namespace SportsManagementApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
           
            services.AddScoped<IEventRequestService , EventRequestService>();
            services.AddScoped<ISportService , SportService>();

        }
    }
}
