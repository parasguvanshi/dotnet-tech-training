using SportsManagementApp.Data.DTOs.Auth;
using SportsManagementApp.Data.DTOs.UserManagement;
using SportsManagementApp.Data.Entities;

namespace SportsManagementApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<LoginResponseDto>> GetUsersAsync();
        Task<LoginResponseDto?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User?> GetUserEntityByIdAsync(int userId);
        Task UpdateUserAsync(User user);
        Task AddUserAsync(User user);            
    }
}