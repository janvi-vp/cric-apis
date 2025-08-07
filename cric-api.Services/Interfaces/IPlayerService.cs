using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.Response;

namespace cric_api.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<PlayerViewModel>> GetAllPlayersByTeamAsync(int teamId);
    }
}