using SportsManagementApp.Data;
using SportsManagementApp.Data.Entities;
using SportsManagementApp.Repositories.Interfaces;

namespace SportsManagementApp.Repositories.Implementations
{
    public class SportRepository : GenericRepository<Sport>, ISportRepository
    {
        public SportRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<TResult>> GetSportsAsyncWithFilter<TResult>(
            Expression<Func<Sport, bool>> predicate,
            Expression<Func<Sport, TResult>> projection)
        {
            return await _dbSet
                .Where(predicate)
                .Select(projection)
                .ToListAsync();
        }
    }
}