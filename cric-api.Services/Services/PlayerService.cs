using cric_api.DTOs.Response;
using cric_api.Repository;
using cric_api.Repository.Interfaces;
using cric_api.Services.Interfaces;

namespace cric_api.Services
{
    public class PlayerService : IPlayerService
    {
        private IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PlayersByTeam>> GetAllPlayersByTeamAsync(Guid teamId)
        {
            return await _repository.GetAllPlayersByTeamAsync(teamId);
        }
    }
}