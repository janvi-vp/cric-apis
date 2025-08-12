using cric_api.DTOs.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cric_api.DTOs.Utilities
{
    public class PaginationRequest : IPaginationRequest
    {
        public virtual int PageNumber { get; set; } = 1;
        public virtual int PageSize { get; set; } = 20;
    }
}
