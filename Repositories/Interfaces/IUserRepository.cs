using SportsManagementApp.Data.DTOs.UserManagement;
using SportsManagementApp.Data.Entities;
using SportsManagementApp.Data.Filters;
using System.Linq.Expressions;

namespace SportsManagementApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersWithRoleAsync();
        Task<User?> GetUserEntityByIdAsync(int userId);
        Task<UserResponseDto?> GetUserDtoByIdAsync(int userId);
        Task<List<UserResponseDto>> GetUsersByFilterAsync(UserFilterDto filter);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}