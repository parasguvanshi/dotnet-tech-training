using System.Linq.Expressions;
namespace SportsManagementApp.Repositories.Interfaces;
public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity);
    void Update(T entity);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    Task<int> SaveChangesAsync();
}