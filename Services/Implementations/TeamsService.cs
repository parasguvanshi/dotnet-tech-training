using AutoMapper;
using SportsManagementApp.Data.DTOs.TeamManagement;
using SportsManagementApp.Data.Entities;
using SportsManagementApp.Data.Filters;
using SportsManagementApp.Exceptions;
using SportsManagementApp.Repositories.Interfaces;
using SportsManagementApp.Services.Interfaces;

namespace SportsManagementApp.Services.Implementations
{
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly IParticipantRegistrationRepository _participantRepository;
        private readonly IMapper _mapper;

        public TeamsService(ITeamsRepository teamsRepository, IParticipantRegistrationRepository participantRepository, IMapper mapper)
        {
            _teamsRepository = teamsRepository;
            _participantRepository = participantRepository;
            _mapper = mapper;
        }

        public async Task<List<TeamResponseDto>> GetTeamsAsync(TeamFilterDto filter)
        {
            return await _teamsRepository.GetTeamsByFilterAsync(filter);
        }

        public async Task<List<TeamResponseDto>> CreateTeamsAsync(CreateTeamRequestDto request)
        {
            var registration = await _participantRepository.GetParticipantsByCategoryAsync(request.EventCategoryId);

            if (registration.Count < 2)
                throw new BadRequestException("Not enough participants to form teams");

            if (registration.Count % 2 != 0)
                registration.RemoveAt(registration.Count - 1);

            var random = new Random();
            for (int i = registration.Count - 1; i > 0; i--)
            {
                int swap = random.Next(i + 1);
                (registration[i], registration[swap]) = (registration[swap], registration[i]);
            }

            int teamNumber = 1;
            var result = new List<TeamResponseDto>();

            for (int i = 0; i < registration.Count; i += 2)
            {
                var team = _mapper.Map<Team>(request);
                team.Name = $"Team {teamNumber}";
                team.CreatedAt = DateTime.UtcNow;
                team.Members = new List<TeamMember>
                {
                    new() { UserId = registration[i].UserId },
                    new() { UserId = registration[i + 1].UserId }
                };

                await _teamsRepository.AddTeamAsync(team);
                result.Add(_mapper.Map<TeamResponseDto>(team));
                teamNumber++;
            }

            return result;
        }
    }
}