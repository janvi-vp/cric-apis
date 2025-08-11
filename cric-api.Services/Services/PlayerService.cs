using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.Response;
using cric_api.Models;
using cric_api.Repository;
using cric_api.Repository.Interfaces;
using cric_api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace cric_api.Services
{
    public class PlayerService : IPlayerService
    {
        private IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task AddPlayer(CreatePlayer player)
        {
            await _repository.AddPlayer(player);
        }

        public async Task DeletePlayer(int id)
        {
            await _repository.DeletePlayer(id);
        }

        public async Task EditPlayer(EditPlayer editPlayer, int id)
        {
            var isExist = await _repository.IsExist(id);

            if (!isExist)
            {
                throw new Exception("No such player exists!");
            }

            var entity = await _repository.GetPlayerById(id);

            if (!string.IsNullOrEmpty(editPlayer.FirstName) && editPlayer.FirstName != entity.FirstName)
            {
                entity.FirstName = editPlayer.FirstName;
            }

            if (!string.IsNullOrEmpty(editPlayer.LastName) && editPlayer.LastName != entity.LastName)
            {
                entity.LastName = editPlayer.LastName;
            }

            if (!string.IsNullOrEmpty(editPlayer.Email) && editPlayer.Email != entity.Email)
            {
                entity.Email = editPlayer.Email;
            }

            if (editPlayer.Birthday.HasValue && editPlayer.Birthday.Value != entity.Birthday)
            {
                entity.Birthday = editPlayer.Birthday.Value;
            }

            if (!string.IsNullOrEmpty(editPlayer.BirthPlace) && editPlayer.BirthPlace != entity.BirthPlace)
            {
                entity.BirthPlace = editPlayer.BirthPlace;
            }

            if (editPlayer.Role.HasValue && editPlayer.Role.Value != entity.RoleEnum)
            {
                entity.RoleEnum = editPlayer.Role.Value;
            }

            await _repository.EditPlayer(entity);
        }

        public async Task<List<PlayerViewModel>> GetAllPlayers(int pageNumber, int pageSize)
        {
            return await _repository.GetAllPlayers(pageNumber, pageSize);
        }

        public async Task<List<PlayerViewModel>> GetAllPlayersByFilter(string firstName, string lastName, string email)
        {
            return await _repository.GetAllPlayersByFilter(firstName, lastName, email);
        }

        public async Task<List<PlayerViewModel>> GetALlPlayersBySorting(string sortingParam)
        {
            return await _repository.GetALlPlayersBySorting(sortingParam);
        }

        public async Task<PlayerViewModel> GetPlayerById(int id)
        {
            return await _repository.GetPlayerById(id);
        }
    }
}