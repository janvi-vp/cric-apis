using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.Models.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
    }
}