using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Data;
using cric_api.DTOs.DTOs.Request;
using cric_api.Models.Models;
using cric_api.Repository.Interfaces;
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
        public async Task ScheduleMatch(ScheduleMatch match)
        {
            var newMatch = new Match
            {
                Title = $"{match.HomeTeamId} vs {match.AwayTeamId}",
                MatchType = match.MatchType,
                DateTime = match.DateTime,
                VenueId = match.VenueId,
                HomeTeamId = match.HomeTeamId,
                AwayTeamId = match.AwayTeamId            
            };

            foreach (var playerId in match.HomeTeamSquad)
            {
                newMatch.MatchPlayers.Add(new MatchPlayer
                {
                    PlayerId = playerId,
                    TeamSide = TeamSide.Home
                });
            }

            foreach (var playerId in match.AwayTeamSquad)
            {
                newMatch.MatchPlayers.Add(new MatchPlayer
                {
                    PlayerId = playerId,
                    TeamSide = TeamSide.Away
                });
            }

            await _context.Matches.AddAsync(newMatch);
            await _context.SaveChangesAsync();

        }
    }
}