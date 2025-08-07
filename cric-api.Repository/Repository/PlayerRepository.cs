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

        public async Task<List<PlayersByTeam>> GetAllPlayersByTeamAsync(Guid teamId)
        {
            return await _context.Players.Where(p => p.Team.Id == teamId).Select(s => new PlayersByTeam
                {
                    Id = s.Id,
                    Name = s.Name,
                    Age = s.Age,
                    Role = s.Role
                }).ToListAsync();
        }
    }
}