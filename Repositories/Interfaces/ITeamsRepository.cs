using SportsManagementApp.Data.DTOs.Participant;

namespace SportsManagementApp.Repositories.Interfaces
{
    public interface ITeamsRepository
    {
        Task<List<MyTeamDto>> GetUserTeamsAsync(int userId);
    }
}
