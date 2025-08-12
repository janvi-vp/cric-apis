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
        Task<PaginatedResponse<PlayerViewModel>> GetPlayers(GetPlayersRequestModel request);

        Task<List<PlayerViewModel>> GetAllPlayers(int pageNumber, int pageSize);

        Task<List<PlayerViewModel>> GetAllPlayersByFilter(string firstName, string lastName, string email);

        Task<List<PlayerViewModel>> GetALlPlayersBySorting(string sortingParam);

        Task<PlayerViewModel> GetPlayerById(int id);

        Task<PlayerViewModel> AddPlayer(CreatePlayer player);

        Task<PlayerViewModel> EditPlayer(EditPlayer editPlayer, int id);

        Task DeletePlayer(int id);
    }
}