using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Data;
using cric_api.Models;
using cric_api.DTOs.Response;
using Microsoft.EntityFrameworkCore;
using cric_api.Repository.Interfaces;

namespace cric_api.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly CricContext _context;
        public PlayerRepository(CricContext context)
        {
            _context = context;
        }

        public async Task<List<PlayerViewModel>> GetAllPlayersByTeamAsync(int teamId)
        {
            var players = await _context.Players.Where(p => p.Team.Id == teamId).ToListAsync();
            return ToPlayersByTeam(players);

        }

        private PlayerViewModel ToPlayerByTeam(Player player)
        {
            return new PlayerViewModel
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Email = player.Email,
                Role = player.Role.ToString()
            };
        }

        private List<PlayerViewModel> ToPlayersByTeam(List<Player> players)
        {
            return players.Select(s => ToPlayerByTeam(s)).ToList();
        } 
    }
}