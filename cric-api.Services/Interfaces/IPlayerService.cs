using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.Response;
using cric_api.DTOs.Utilities;
using cric_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<PaginatedResponse<PlayerViewModel>> GetAllPlayers(GetPlayersRequestModel request);

        Task<PlayerViewModel> GetPlayerById(int id);

        Task<PlayerViewModel> AddPlayer(CreatePlayer player);

        Task<PlayerViewModel> EditPlayer(EditPlayer editPlayer, int id);

        Task DeletePlayer(int id);
    }
}