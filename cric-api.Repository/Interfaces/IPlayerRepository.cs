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
        Task<List<PlayerViewModel>> GetAllPlayers(int pageNumber, int pageSize);

        Task<List<PlayerViewModel>> GetAllPlayersByFilter(string firstName, string lastName, string email);

        Task<List<PlayerViewModel>> GetALlPlayersBySorting(string sortingParam);

        Task<PlayerViewModel> GetPlayerById(int id);

        Task<bool> IsExist(int id);

        Task AddPlayer(CreatePlayer player);

        Task EditPlayer(PlayerViewModel player);

        Task DeletePlayer(int id);
        Task<PaginatedResponse<PlayerViewModel>> GetPlayers(GetPlayersRequestModel request);
    }
}