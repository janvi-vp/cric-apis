using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.DTOs.Response
{
    public class PlayersByTeam
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Role { get; set; }
    }
}