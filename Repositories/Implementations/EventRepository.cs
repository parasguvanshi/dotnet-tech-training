using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SportsManagementApp.Data;
using SportsManagementApp.Data.Entities;
using SportsManagementApp.Repositories.Interfaces;

namespace SportsManagementApp.Repositories.Implementations
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context) { }
        public override async Task<Event?> GetByIdAsync(int id) =>
            await GetByIdWithDetailsAsync(id);

        public override async Task<List<Event>> GetAllAsync(Expression<Func<Event, bool>> predicate)
        {
            return await _context.Events
                .AsNoTracking()
                .Where(predicate)
                .Include(e => e.Sport)
                .Include(e => e.Organizer)
                .Include(e => e.Categories)
                .ToListAsync();
        }

        public async Task<Event?> GetByIdWithDetailsAsync(int eventId) =>
            await _context.Events
                .Include(e => e.Sport)
                .Include(e => e.Organizer)
                .Include(e => e.EventRequest)
                .Include(e => e.Categories)
                .FirstOrDefaultAsync(e => e.Id == eventId);
    }
}