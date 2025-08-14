using cric_api.DTOs.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cric_api.DTOs.DTOs.Request
{
    public class GetPlayersRequestModel : PaginatedSortingRequest
    {
        public string? SearchText { get; set; }
    }
}
