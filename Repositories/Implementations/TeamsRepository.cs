using Microsoft.EntityFrameworkCore;
using SportsManagementApp.Data;
using SportsManagementApp.Data.DTOs.TeamManagement;
using SportsManagementApp.Data.Entities;
using SportsManagementApp.Data.Filters;
using SportsManagementApp.Repositories.Interfaces;

namespace SportsManagementApp.Repositories.Implementations
{
    public class TeamsRepository : GenericRepository<Team>, ITeamsRepository
    {
        public TeamsRepository(AppDbContext context) : base(context) { }

        public async Task<List<TeamResponseDto>> GetTeamsByFilterAsync(TeamFilterDto filter)
        {
            var query = _dbSet.Include(team => team.Members)
                              .ThenInclude(m => m.User)
                              .AsQueryable();

            if (filter.UserId.HasValue)
                query = query.Where(team => team.Members.Any(m => m.UserId == filter.UserId.Value));

            if (filter.CategoryId.HasValue)
                query = query.Where(team => team.EventCategoryId == filter.CategoryId.Value);

            return await query
                .Select(team => new TeamResponseDto
                {
                    Id = team.Id,
                    Name = team.Name,
                    EventCategoryId = team.EventCategoryId,
                    Members = team.Members
                                 .Select(m => m.User != null ? m.User.FullName : "N/A")
                                 .ToList()
                })
                .ToListAsync();
        }

        public async Task AddTeamAsync(Team team)
        {
            await _dbSet.AddAsync(team);
            await _context.SaveChangesAsync();
        }
    }
}