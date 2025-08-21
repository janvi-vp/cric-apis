using cric_api.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cric_api.DTOs.DTOs.Response
{
    public class MatchViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Utilities.Enums.MatchType MatchTypeEnum { get; set; }
        public string MatchType { get; set; }
        public VenueViewModel Venue { get; set; }
        public TeamViewModel HomeTeam { get; set; }
        public TeamViewModel AwayTeam { get; set; }
    }
}
