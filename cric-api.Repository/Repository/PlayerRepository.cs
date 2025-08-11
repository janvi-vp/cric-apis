using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Data;
using cric_api.Models;
using cric_api.DTOs.Response;
using Microsoft.EntityFrameworkCore;
using cric_api.Repository.Interfaces;
using cric_api.DTOs.DTOs.Request;

namespace cric_api.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly CricContext _context;
        public PlayerRepository(CricContext context)
        {
            _context = context;
        }

        public async Task AddPlayer(CreatePlayer player)
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
        
        public async Task EditPlayer(PlayerViewModel player)
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
        }

        public async Task<List<PlayerViewModel>> GetAllPlayers(int pageNumber, int pageSize)
        {
            var players = await _context.Players.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return ToPlayersByTeam(players);
        }

        public async Task<List<PlayerViewModel>> GetAllPlayersByFilter(string firstName, string lastName, string email)
        {
            var players = await _context.Players.Where(p => p.FirstName.Contains(firstName) || p.LastName.Contains(lastName) || p.Email.Contains(email)).ToListAsync();
            return ToPlayersByTeam(players);
        }

        public async Task<List<PlayerViewModel>> GetALlPlayersBySorting(string sortingParam)
        {
            if (sortingParam == "DSC")
            {
                var players = await _context.Players.Order().ToListAsync();
                return ToPlayersByTeam(players);
            }
            else
            {
                var players = await _context.Players.OrderDescending().ToListAsync();
                return ToPlayersByTeam(players);
            }
        }

        public async Task<PlayerViewModel> GetPlayerById(int id)
        {
            var player = await _context.Players.Where(p => p.Id == id).FirstOrDefaultAsync();
            return ToPlayerByTeam(player);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Players.AnyAsync(p => p.Id == id);
        }

        private PlayerViewModel ToPlayerByTeam(Player player)
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

        private List<PlayerViewModel> ToPlayersByTeam(List<Player> players)
        {
            return players.Select(s => ToPlayerByTeam(s)).ToList();
        } 
    }
}