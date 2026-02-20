using Microsoft.EntityFrameworkCore;
using SportsManagementApp.Data;
using SportsManagementApp.Enums;
using SportsManagementApp.Entities;
using SportsManagementApp.DTOs;

namespace SportsManagementApp.Repositories.EventRequestRepository;

public class EventRequestRepository : IEventRequestRepository
{
    private readonly AppDbContext _context;

    public EventRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddEventRequest(EventRequest eventRequest)
    {
        _context.EventRequests.Add(eventRequest);
        await _context.SaveChangesAsync();
    }

    public async Task<List<EventRequest>> GetAllEventRequest()
        {
            var eventRequests = await _context.EventRequests.ToListAsync();
            return eventRequests;
        }

    public async Task<EventRequest?> GetEventRequestById(int id)
    {
        var eventRequest = await _context.EventRequests.FirstOrDefaultAsync(
            x => x.Id == id
        );

        return eventRequest;
    }

    public async Task<List<EventRequest>> GetEventRequestByStatus(RequestStatus status)
    {
        var eventRequest = await _context.EventRequests.Where(
            x => x.Status == status
        ).ToListAsync();

        return eventRequest;
    }

    public async Task<EventRequest> UpdateEventRequest(EventRequest request)
    {
        _context.EventRequests.Update(request);
        await _context.SaveChangesAsync();
        return request;
    }   

    public async Task<bool> EventRequestExist(CreateEventRequestDto dto)
    {

        var name = dto.EventName.Trim().ToLower();

        return await _context.EventRequests.AnyAsync(e =>
        e.SportId == dto.SportId &&
        e.Gender == dto.Gender &&
        e.Format == dto.Format &&
        e.StartDate == dto.StartDate
    );
    }

         
}