using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static cric_api.DTOs.Utilities.Enums;

namespace cric_api.Models.Models
{
    public class Match
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required DTOs.Utilities.Enums.MatchType MatchType { get; set; }

        public required DateTime DateTime { get; set; }

        public int VenueId { get; set; }

        public Venue Venue { get; set; }

        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }

        public List<MatchPlayer> MatchPlayers { get; set; } = new List<MatchPlayer>();

    }
}