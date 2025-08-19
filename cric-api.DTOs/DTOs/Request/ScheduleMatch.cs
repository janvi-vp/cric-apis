using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.DTOs.DTOs.Request
{
    public class ScheduleMatch
    {
        public Utilities.Enums.MatchType MatchType { get; set; }
        public DateTime DateTime { get; set; }
        public int VenueId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public List<int> HomeTeamSquad { get; set; } = new();
        public List<int> AwayTeamSquad { get; set; } = new();
    }
}