using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;
using cric_api.DTOs.Utilities;
using cric_api.Repository.Interfaces;
using cric_api.Services.Interfaces;

namespace cric_api.Services.Services
{
    public class TeamService : ITeamService
    {
        private ITeamRepository _repository;

        public TeamService(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<TeamPlayerViewModel> AddPlayerToTeam(int teamId, int playerId)
        {
            var newTeamPlayer = await _repository.AddPlayerToTeam(teamId, playerId);
            return newTeamPlayer;
        }

        public async Task<TeamViewModel> AddTeam(CreateTeam team)
        {
            var newTeam = await _repository.AddTeam(team);
            return newTeam;
        }

        public async Task DeleteTeam(int id)
        {
            await _repository.DeleteTeam(id);
        }

        public async Task<TeamViewModel> EditTeam(int id, string name)
        {
            var isExist = await _repository.IsExist(id);

            if (!isExist)
            {
                throw new Exception("No such team exists!");
            }

            var entity = await _repository.GetTeamById(id);

            if (!string.IsNullOrEmpty(name) && name != entity.Name)
            {
                entity.Name = name;
            }

            var editedTeam = await _repository.EditTeam(id, name);
            return editedTeam;
            
        }

        public async Task<TeamViewModel> GetTeamById(int id)
        {
            return await _repository.GetTeamById(id);
        }

        public async Task<TeamPlayerViewModel> GetTeamPlayerById(int id)
        {
            return await _repository.GetTeamPlayerById(id);
        }

        public async Task<PaginatedResponse<TeamViewModel>> GetTeams(GetTeamsRequestModel request)
        {
            return await _repository.GetTeams(request);
        }

        public async Task RemovePlayerFromTeam(int teamId, int playerId)
        {
            await _repository.RemovePlayerFromTeam(teamId, playerId);
        }
    }
}