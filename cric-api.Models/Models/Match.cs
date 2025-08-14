using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static cric_api.DTOs.Utilities.Enums;

namespace cric_api.Models.Models
{
    public class Match
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required TypeOfMatch TypeOfMatch { get; set; }

        public required DateTime DateTime { get; set; }

        public int VenueId { get; set; }

        public required Venue Venue { get; set; }

        public int Team1Id { get; set; }

        public required Team Team1 { get; set; }

        public int Team2Id { get; set; }

        public required Team Team2 { get; set; }

    }
}