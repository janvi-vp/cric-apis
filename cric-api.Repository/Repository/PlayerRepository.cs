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

        public async Task<PaginatedResponse<PlayerViewModel>> GetAllPlayers(GetPlayersRequestModel request)
        {
            IQueryable<Player> query = _context.Players;

            if (!string.IsNullOrEmpty(request.SearchText))
            {
                query = query.Where(x => x.FirstName.Contains(request.SearchText) || x.LastName.Contains(request.SearchText) || x.Email.Contains(request.SearchText));
            }

            query = query.OrderByColumn(request.SortByColumn, request.SortDirection == Enums.SortDirection.ASC);

            var result = await query.ToPaginatedAsync(request);

            return new PaginatedResponse<PlayerViewModel>(ToPlayerViewModel(result.Items.ToList()), result.TotalCount, result.PageNumber, result.PageSize);
        }

        public async Task<PlayerViewModel> GetPlayerById(int id)
        {
            var player = await _context.Players.Where(p => p.Id == id).FirstAsync();
            return ToPlayerViewModel(player);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Players.AnyAsync(p => p.Id == id);
        }

        private PlayerViewModel ToPlayerViewModel(Player player)
        {
            return new PlayerViewModel
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Email = player.Email,
                Birthday = player.Birthday,
                BirthPlace = player.BirthPlace,
                Role = player.Role.ToString(),
                RoleEnum = player.Role
            };
        }

        private List<PlayerViewModel> ToPlayerViewModel(List<Player> players)
        {
            return players.Select(s => ToPlayerViewModel(s)).ToList();
        } 
    }
}