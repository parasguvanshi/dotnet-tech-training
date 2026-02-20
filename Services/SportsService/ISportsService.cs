using SportsManagementApp.DTOs;
using SportsManagementApp.Entities;

namespace SportsManagementApp.Services
{
    public interface ISportService
    {
        Task<Sport> CreateSport(CreateSportDto dto);
        Task<IEnumerable<Sport>> GetAllSports();
        Task<Sport?> GetSportById(int id);
        
    }
}
