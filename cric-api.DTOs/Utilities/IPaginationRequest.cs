using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cric_api.DTOs.Utilities
{
    public interface IPaginationRequest
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
    }
}
