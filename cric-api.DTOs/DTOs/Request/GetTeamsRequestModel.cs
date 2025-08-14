using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.Utilities;

namespace cric_api.DTOs.DTOs.Request
{
    public class GetTeamsRequestModel : PaginatedSortingRequest
    {
        public string? SearchText { get; set; }

        public int? PlayerId { get; set; }
    }
}