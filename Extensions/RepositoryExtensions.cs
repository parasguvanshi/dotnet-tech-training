
using SportsManagementApp.Repositories;
using SportsManagementApp.Repositories.EventRequestRepository;
using SportsManagementApp.Repositories.SportsRepository;


namespace SportsManagementApp.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEventRequestRepository , EventRequestRepository>();
            services.AddScoped<ISportRepository, SportRepository>();
            
        }
    }
}
