using cric_api.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.DTOs.DTOs.Response
{
    public class TeamPlayerViewModel
    {
        public int Id { get; set; }

        public TeamViewModel Team { get; set; }

        public PlayerViewModel Player { get; set; }

    }
}