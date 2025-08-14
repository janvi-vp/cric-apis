using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.Models.Models
{
    public class TeamPlayer
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int PlayerId { get; set; }
        
        public Player Player { get; set; }

    }
}