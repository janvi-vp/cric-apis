using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.Response;

namespace cric_api.Repository.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<PlayersByTeam>> GetAllPlayersByTeamAsync(Guid teamId);
    }
}