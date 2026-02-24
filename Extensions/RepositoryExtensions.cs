
using SportsManagementApp.Repositories.Implementations;
using SportsManagementApp.Repositories.Interfaces;



namespace SportsManagementApp.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));    
            services.AddScoped<IEventRequestRepository , EventRequestRepository>();
            services.AddScoped<ISportRepository, SportRepository>();    
        }
    }
}
