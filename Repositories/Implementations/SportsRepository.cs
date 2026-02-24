using Microsoft.EntityFrameworkCore;
using SportsManagementApp.Data;
using SportsManagementApp.Entities;
using SportsManagementApp.Repositories.Interfaces;

namespace SportsManagementApp.Repositories.Implementations;

public class SportRepository : GenericRepository<Sport>, ISportRepository
{
    public SportRepository(AppDbContext context) : base(context) { }

    public async Task<List<Sport>> SearchSports(int? id, string? name)
    {
        var query = _context.Sports.AsQueryable();

        if (id.HasValue){
            query = query.Where(s => s.Id == id.Value);
        }

        var Name = name?.Trim().ToLower();

        if (!string.IsNullOrWhiteSpace(Name)){
            query = query.Where(s => s.Name.ToLower() == Name);
        }

        return await query.ToListAsync();
    }

    public async Task<Sport?> GetSportByName(string name)
    {
        var Name = name.Trim().ToLower();
        return await _context.Sports.FirstOrDefaultAsync(s => s.Name.ToLower() == Name);
    }

}