using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;
using cric_api.DTOs.Utilities;

namespace cric_api.Repository.Interfaces
{
    public interface ITeamRepository
    {
        Task<PaginatedResponse<TeamViewModel>> GetTeams(GetTeamsRequestModel request);

        Task<TeamViewModel> AddTeam(CreateTeam team);

        Task<bool> IsExist(int id);

        Task<TeamViewModel> GetTeamById(int id);

        Task<TeamViewModel> EditTeam(int id, string name);

        Task DeleteTeam(int id);
    }
}