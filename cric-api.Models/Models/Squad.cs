using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static cric_api.DTOs.Utilities.Enums;

namespace cric_api.Models.Models
{
    public class Squad
    {
        public int Id { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}