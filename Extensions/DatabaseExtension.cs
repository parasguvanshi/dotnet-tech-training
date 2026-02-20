using Microsoft.EntityFrameworkCore;
using SportsManagementApp.Data;

namespace SportsManagementApp.Extensions;
public static class DatabaseExtension
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))

        );

        
    }
}