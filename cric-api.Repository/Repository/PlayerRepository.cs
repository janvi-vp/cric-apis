using cric_api.Data;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.Response;
using cric_api.DTOs.Utilities;
using cric_api.Models;
using cric_api.Repository.Interfaces;
using cric_api.Repository.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly CricContext _context;
        public PlayerRepository(CricContext context)
        {
            _context = context;
        }

        public async Task<PlayerViewModel> AddPlayer(CreatePlayer player)
        {
            var alreadyExist = await _context.Players.Where(p => p.Email == player.Email).FirstOrDefaultAsync();

            if (alreadyExist == null)
            {
                var newPlayer = new Player()
                {
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    Email = player.Email,
                    Birthday = player.Birthday,
                    BirthPlace = player.BirthPlace,
                    Role = player.Role
                };

                await _context.Players.AddAsync(newPlayer);
                await _context.SaveChangesAsync();
                return await GetPlayerById(newPlayer.Id);
            }

            else
            {
                throw new Exception("Player Already Exists");
            }
        }

        public async Task DeletePlayer(int id)
        {
            var playerToDelete = await _context.Players.FindAsync(id);
            if (playerToDelete != null)
            {
                _context.Players.Remove(playerToDelete);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<PlayerViewModel> EditPlayer(PlayerViewModel player)
        {
            var entity = await _context.Players.FindAsync(player.Id);
            if (entity != null)
            {
                entity.FirstName = player.FirstName;
                entity.LastName = player.LastName;
                entity.Email = player.Email;
                entity.Birthday = player.Birthday;
                entity.BirthPlace = player.BirthPlace;
                entity.Role = player.RoleEnum;

                await _context.SaveChangesAsync();
            }
            return await GetPlayerById(player.Id);
        }

        public async Task<List<PlayerViewModel>> GetAllPlayers(int pageNumber, int pageSize)
        {
            var players = await _context.Players.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return players.ToViewModel();
        }

        public async Task<PaginatedResponse<PlayerViewModel>> GetPlayers(GetPlayersRequestModel request)
        {
            IQueryable<Player> query = _context.Players;

            if (!string.IsNullOrEmpty(request.SearchText))
            {
                query = query.Where(x => x.FirstName.Contains(request.SearchText) || x.LastName.Contains(request.SearchText) || x.Email.Contains(request.SearchText));
            }

            query = query.OrderByColumn(request.SortByColumn, request.SortDirection == Enums.SortDirection.ASC);

            var result = await query.ToPaginatedAsync(request);

            return new PaginatedResponse<PlayerViewModel>(result.Items.ToList().ToViewModel(), result.TotalCount, result.PageNumber, result.PageSize);
        }

        public async Task<List<PlayerViewModel>> GetAllPlayersByFilter(string firstName, string lastName, string email)
        {
            var players = await _context.Players.Where(p => p.FirstName.Contains(firstName) || p.LastName.Contains(lastName) || p.Email.Contains(email)).ToListAsync();
            return players.ToViewModel();
        }

        public async Task<List<PlayerViewModel>> GetALlPlayersBySorting(string sortingParam)
        {
            if (sortingParam == "DSC")
            {
                var players = await _context.Players.Order().ToListAsync();
                return players.ToViewModel();
            }
            else
            {
                var players = await _context.Players.OrderDescending().ToListAsync();
                return players.ToViewModel();
            }
        }

        public async Task<PlayerViewModel> GetPlayerById(int id)
        {
            var player = await _context.Players.Where(p => p.Id == id).FirstOrDefaultAsync();
            return player.ToViewModel();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Players.AnyAsync(p => p.Id == id);
        }
    }
}