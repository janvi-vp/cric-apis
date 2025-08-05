using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_apis.Data;
using cric_apis.Models;
using cric_apis.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace cric_apis.Repository
{
    public class PlayerRepository
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