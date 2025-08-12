using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;
using cric_api.DTOs.Utilities;

namespace cric_api.Services.Interfaces
{
    public interface ITeamService
    {
        Task<PaginatedResponse<TeamViewModel>> GetTeams(GetTeamsRequestModel request);
    }
}