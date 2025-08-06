using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.Models
{
    public class Team
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Player> Players { get; set; }
    }
}