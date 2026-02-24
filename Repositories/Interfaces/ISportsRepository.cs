using SportsManagementApp.Entities;
namespace SportsManagementApp.Repositories.Interfaces;

public interface ISportRepository : IGenericRepository<Sport>
{
    Task<List<Sport>> SearchSports(int? id, string? name);
    Task<Sport?> GetSportByName(string name);
}