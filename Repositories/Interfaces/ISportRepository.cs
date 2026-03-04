using SportsManagementApp.Data.DTOs.SportManagement;
using SportsManagementApp.Data.Entities;
using System.Linq.Expressions;

namespace SportsManagementApp.Repositories.Interfaces
{
    public interface ISportRepository
    {
        Task<bool> SportExistsAsync(string name);
        Task<Sport> CreateSportAsync(string name);
        Task<List<SportResponseDto>> GetSportsAsync(Expression<Func<Sport, bool>> predicate);
        Task<Sport?> GetSportByIdAsync(int id);
        Task UpdateSportAsync(Sport sport);
    }
}
