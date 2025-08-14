using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.Response;
using cric_api.DTOs.Utilities;
using cric_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.Repository.Interfaces
{
    public interface IPlayerRepository
    {
        Task<PlayerViewModel> GetPlayerById(int id);

        Task<bool> IsExist(int id);

        Task <PlayerViewModel> AddPlayer(CreatePlayer player);

        Task <PlayerViewModel> EditPlayer(PlayerViewModel player);

        Task DeletePlayer(int id);

        Task<PaginatedResponse<PlayerViewModel>> GetAllPlayers(GetPlayersRequestModel request);
    }
}