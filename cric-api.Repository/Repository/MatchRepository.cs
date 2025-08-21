using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Data;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;
using cric_api.Models.Models;
using cric_api.Repository.Interfaces;
using cric_api.Repository.Utilities;
using Microsoft.EntityFrameworkCore;
using static cric_api.DTOs.Utilities.Enums;

namespace cric_api.Repository.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly CricContext _context;

        public MatchRepository(CricContext context)
        {
            _context = context;
        }

        public async Task<MatchViewModel> GetById(int id)
        {
            var match = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.Venue)
                .Include(m => m.MatchPlayers).ThenInclude(mp => mp.Player)
            .FirstAsync(m => m.Id == id);

            return match.ToViewModel();
        }

        public async Task<MatchViewModel> ScheduleMatch(ScheduleMatch match)
        {
            var teams = await _context.Teams.Where(t => t.Id == match.HomeTeamId || t.Id == match.AwayTeamId)
                .Select(x => new { Id = x.Id, Name = x.Name }).ToListAsync();

            var newMatch = new Match
            {
                Title = $"{teams.First(t => t.Id == match.HomeTeamId).Name} vs {teams.First(t => t.Id == match.AwayTeamId).Name}",
                MatchType = match.MatchType,
                DateTime = match.DateTime,
                VenueId = match.VenueId,
                HomeTeamId = match.HomeTeamId,
                AwayTeamId = match.AwayTeamId            
            };

            foreach (var playerId in match.HomeTeamSquad)
            {
                newMatch.MatchPlayers.Add(new Squad
                {
                    PlayerId = playerId,
                    TeamId = match.HomeTeamId
                });
            }

            foreach (var playerId in match.AwayTeamSquad)
            {
                newMatch.MatchPlayers.Add(new Squad
                {
                    PlayerId = playerId,
                    TeamId = match.AwayTeamId
                });
            }

            await _context.Matches.AddAsync(newMatch);
            await _context.SaveChangesAsync();

            return await GetById(newMatch.Id);
        }

    }
}