using cric_api.DTOs.DTOs.Response;
using cric_api.DTOs.Response;
using cric_api.Models;
using cric_api.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cric_api.Repository.Utilities
{
    public static class MappingProfile
    {
        public static TeamViewModel ToViewModel(this Team team)
        {
            return new TeamViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Players = team.TeamPlayers.Select(x => x.Player.ToViewModel()).ToList()
            };
        }

        public static List<TeamViewModel> ToViewModel(this List<Team> teams)
        {
            return teams.Select(s => s.ToViewModel()).ToList();
        }

        public static PlayerViewModel ToViewModel(this Player player)
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

        public static List<PlayerViewModel> ToViewModel(this List<Player> players)
        {
            return players.Select(s => s.ToViewModel()).ToList();
        }

        public static VenueViewModel ToViewModel(this Venue venue)
        {
            return new VenueViewModel
            {
                Id = venue.Id,
                Name = venue.Name,
                City = venue.City,
                State = venue.State,
                Country = venue.Country
            };
        }

        public static List<VenueViewModel> ToViewModel(this List<Venue> venues)
        {
            return venues.Select(s => s.ToViewModel()).ToList();
        }

        public static List<MatchViewModel> ToViewMode(this List<Match> matches)
        {
            return matches.Select(m => m.ToViewModel()).ToList();
        }

        public static MatchViewModel ToViewModel(this Match match) 
        {
            var matchViewModel = new MatchViewModel()
            {
                Id = match.Id,
                Title = match.Title,
                MatchTypeEnum = match.MatchType,
                MatchType = match.MatchType.ToString(),
                Venue = match.Venue.ToViewModel(),
                HomeTeam = match.HomeTeam.ToViewModel(),
                AwayTeam = match.AwayTeam.ToViewModel(),
                HomeTeamCaptain = match.HomeTeamCaptain.ToViewModel(),
                HomeTeamWicketkeeper = match.HomeTeamWicketkeeper.ToViewModel(),
                AwayTeamCaptain = match.AwayTeamCaptain.ToViewModel(),
                AwayTeamWicketkeeper = match.AwayTeamWicketkeeper.ToViewModel()
            };

            matchViewModel.HomeTeam.Players = match.MatchPlayers.Where(mp => mp.MatchId == match.Id && mp.TeamId == match.HomeTeamId).Select(x => x.Player.ToViewModel()).ToList();
            matchViewModel.AwayTeam.Players = match.MatchPlayers.Where(mp => mp.MatchId == match.Id && mp.TeamId == match.AwayTeamId).Select(x => x.Player.ToViewModel()).ToList();

            return matchViewModel;
        }
    }
}
