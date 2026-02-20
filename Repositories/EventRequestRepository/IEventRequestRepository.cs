using SportsManagementApp.DTOs;
using SportsManagementApp.Entities;
using SportsManagementApp.Enums;


namespace SportsManagementApp.Repositories;
public interface IEventRequestRepository
{
    Task AddEventRequest(EventRequest request);
    Task<List<EventRequest>> GetAllEventRequest();
    Task<EventRequest?> GetEventRequestById(int id);
    Task<List<EventRequest>> GetEventRequestByStatus(RequestStatus status);
    Task<EventRequest> UpdateEventRequest(EventRequest request);
    Task<bool> EventRequestExist(CreateEventRequestDto dto);
}