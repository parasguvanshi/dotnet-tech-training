using SportsManagementApp.Data.DTOs.Participant;
using SportsManagementApp.Data.DTOs.TeamManagement;
using SportsManagementApp.Data.Entities;
using SportsManagementApp.Data.Filters;
using System.Collections;

namespace SportsManagementApp.Repositories.Interfaces
{
    public interface ITeamsRepository: IGenericRepository<Team>
    {
        Task AddTeamAsync(Team team);
        Task<List<TeamResponseDto>> GetTeamsByFilterAsync(TeamFilterDto filter);
    }
}
