using SportsManagementApp.Data.DTOs.Participant;
using SportsManagementApp.Repositories.Interfaces;
using SportsManagementApp.Services.Interfaces;

namespace SportsManagementApp.Services.Implementations
{
    public class SchedulesService: ISchedulesService
    {
        private readonly ISchedulesRepository _participantRepository;

        public SchedulesService(ISchedulesRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public Task<List<MyScheduleDto>> GetUserSchedulesAsync(int userId)
        {
            return _participantRepository.GetUserScheduleAsync(userId);
        }
    }
}
