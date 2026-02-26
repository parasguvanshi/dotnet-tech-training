using SportsManagementApp.Data.DTOs.Participant;

namespace SportsManagementApp.Services.Interfaces
{
    public interface ITeamsService
    {
        Task<List<MyTeamDto>> GetUserTeamsAsync(int userId);
    }
}
