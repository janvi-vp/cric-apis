using System;
using System.Collections.Generic;
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
    }
}