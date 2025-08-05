using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_apis.Models
{
    public class Player
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Role { get; set; }

        public Team Team { get; set; }
    }
}