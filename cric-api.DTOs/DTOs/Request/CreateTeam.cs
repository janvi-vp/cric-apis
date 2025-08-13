using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.DTOs.DTOs.Request
{
    public class CreateTeam
    {
        public required string Name { get; set; }

        public List<int> PlayerIds { get; set; }
        
    }
}