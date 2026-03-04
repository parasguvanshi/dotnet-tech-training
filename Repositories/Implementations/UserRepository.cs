using Microsoft.EntityFrameworkCore;
using SportsManagementApp.Data;
using SportsManagementApp.Data.DTOs.UserManagement;
using SportsManagementApp.Data.Entities;
using SportsManagementApp.Data.Filters;
using SportsManagementApp.Data.Predicates;
using SportsManagementApp.Data.Projections;
using SportsManagementApp.Repositories.Interfaces;

namespace SportsManagementApp.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<List<User>> GetUsersWithRoleAsync()
        {
            return await _dbSet
                .Include(user => user.Role)
                .ToListAsync();
        }

        public async Task<User?> GetUserEntityByIdAsync(int userId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<UserResponseDto?> GetUserDtoByIdAsync(int userId)
        {
            return await _dbSet
                .Where(user => user.Id == userId)
                .Select(UserProjectionBuilder.Build())
                .FirstOrDefaultAsync();
        }

        public async Task<List<UserResponseDto>> GetUsersByFilterAsync(UserFilterDto filter)
        {
            var predicate = UserPredicateBuilder.Build(filter);

            return await _dbSet
                .Include(user => user.Role)
                .Where(predicate)
                .Select(UserProjectionBuilder.Build())
                .ToListAsync();
        }
    }
}