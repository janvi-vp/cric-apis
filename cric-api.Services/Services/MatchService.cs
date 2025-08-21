using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;
using cric_api.Repository.Interfaces;
using cric_api.Services.Interfaces;

namespace cric_api.Services.Services
{
    public class MatchService : IMatchService
    {
        private IMatchRepository _repository;
        private ITeamRepository _teamRepository;

        public MatchService(IMatchRepository repository, ITeamRepository teamRepository)
        {
            _repository = repository;
            _teamRepository = teamRepository;
        }

        public async Task<MatchViewModel> ScheduleMatch(ScheduleMatch match)
        {
            match.HomeTeamSquad = match.HomeTeamSquad.Distinct().ToList();
            match.AwayTeamSquad = match.AwayTeamSquad.Distinct().ToList();

            if (match.HomeTeamId == match.AwayTeamId)
            {
                throw new ArgumentException("Home team and away team cannot be the same.");
            }

            var homeTeamSquad = await _teamRepository.CheckIfPayersInTeam(match.HomeTeamId, match.HomeTeamSquad);

            if (homeTeamSquad.Count() != match.HomeTeamSquad.Count())
            {
                throw new ArgumentException("Some players from home team squad are not in home team");
            }

            //if (homeTeamSquad.Count != 11)
            //{
            //    throw new ArgumentException("Home team squad must have exactly 11 players.");
            //}

            var awayTeamSquad = await _teamRepository.CheckIfPayersInTeam(match.AwayTeamId, match.AwayTeamSquad);

            if (awayTeamSquad.Count() != match.AwayTeamSquad.Count())
            {
                throw new ArgumentException("Some players from away team squad are not in away team");
            }

            //if (awayTeamSquad.Count != 11)
            //{
            //    throw new ArgumentException("Away team squad must have exactly 11 players.");
            //}

            return await _repository.ScheduleMatch(match);
        }
    }
}