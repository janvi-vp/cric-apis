using cric_api.DTOs.Response;
using cric_api.Repository;

namespace cric_api.Services
{
    public class PlayerService
    {
        private PlayerRepository _repository;

        public PlayerService(PlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PlayersByTeam>> GetAllPlayersByTeamAsync(Guid teamId)
        {
            return await _repository.GetAllPlayersByTeamAsync(teamId);
        }
    }
}