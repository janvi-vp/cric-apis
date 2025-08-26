using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Models.Models;
using static cric_api.DTOs.Utilities.Enums;

namespace cric_api.Models
{
    public class Player
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public DateOnly Birthday { get; set; }

        public string? BirthPlace { get; set; }

        public required PlayerRole Role { get; set; }

        public List<Match> MatchesAsHomeTeamCaptain { get; set; }

        public List<Match> MatchesAsHomeTeamWicketKeeper { get; set; }

        public List<Match> MatchesAsAwayTeamCaptain { get; set; }

        public List<Match> MatchesAsAwayTeamWicketKeeper { get; set; }
        
        public List<TeamPlayer> TeamPlayers { get; set; }
    }
}