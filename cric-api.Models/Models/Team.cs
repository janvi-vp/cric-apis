using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Models.Models;

namespace cric_api.Models
{
    public class Team
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public List<TeamPlayer> TeamPlayers { get; set; } = [];

        [NotMapped]
        public List<Match> Matches { get; set; } = [];
    }
}