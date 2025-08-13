using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.DTOs.DTOs.Response
{
    public class TeamPlayerViewModel
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int PlayerId { get; set; }

    }
}